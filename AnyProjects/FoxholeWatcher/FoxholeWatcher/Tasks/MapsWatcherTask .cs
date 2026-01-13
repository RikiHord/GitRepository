using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Foxhole.Class;
using FoxholeWatcher.Foxhole.Models;
using FoxholeWatcher.Services;
using System.Text.Json;
using System.Xml.Linq;

namespace FoxholeWatcher.Tasks
{
    public class MapsWatcherTask: IFoxholeTask
    {
        private readonly FoxholeApiClient _foxhole;
        private readonly ILoggerService _logger;
        private readonly INotificationService _notifier;

        private HexData[] _hexDatas = [];
        private bool _initialized = false;

        public MapsWatcherTask(FoxholeApiClient foxhole, ILoggerService logger, INotificationService notifier)
        {
            _foxhole = foxhole ?? throw new ArgumentNullException(nameof(foxhole));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ExecuteAsync()
        {
            if (!_initialized)
            {
                await InitializeAsync();
                _initialized = true;
                return;
            }

            await UpdateAsync();
        }

        private async Task InitializeAsync()
        {
            var maps = await _foxhole.GetMapsAsync(); // string[] maps
            if (maps == null || maps.Length == 0)
                throw new Exception("No maps found from Foxhole API.");

            _hexDatas = new HexData[maps.Length];

            for (int i = 0; i < maps.Length; i++)
            {
                try
                {
                    _hexDatas[i] = await _foxhole.GetDynamicMapDataAsync(maps[i]);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to get initial data for hex {maps[i]}: ", ex);
                    _hexDatas[i] = new HexData(maps[i], new List<string>());
                }
            }

            _logger.Info($"Initialized {_hexDatas.Length} hexes");
        }

        private async Task UpdateAsync()
        {
            bool dataUpdateCorrect = true;
            List<string> errorUpdateHexNames = new List<string>();
            SemaphoreSlim semaphore = new SemaphoreSlim(5); // Max 5 concurrent requests

            var tasks = _hexDatas.Select(async hex =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var freshData = await _foxhole.GetDynamicMapDataAsync(hex.HexName);
                    bool colonialLost = hex.HasLostBase("COLONIALS", freshData.TeamIds);
                    hex.SetTeamIds(freshData.TeamIds);

                    if (colonialLost)
                    {
                        _logger.Info($"Hex {hex.HexName} colonial lost base!");
                        await _notifier.SendMessageAsync($"Hex {hex.HexName} colonial lost base!");
                    }
                }
                catch (Exception ex)
                {
                    dataUpdateCorrect = false;
                    errorUpdateHexNames.Add(hex.HexName);  
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);
            if (dataUpdateCorrect)
            {
                _logger.Info($"Map data update {DateTime.Now}");
            }
            else
            {
                _logger.Warning($"Failed to update hex(s): {string.Join(" ", errorUpdateHexNames)}");
            }
        }
    }
}
