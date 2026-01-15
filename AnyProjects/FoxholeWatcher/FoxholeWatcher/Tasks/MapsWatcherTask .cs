using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Foxhole.Class;
using FoxholeWatcher.Foxhole.Models;
using FoxholeWatcher.Services;

namespace FoxholeWatcher.Tasks
{
    public class MapsWatcherTask : IFoxholeTask
    {
        private readonly FoxholeApiClient _foxhole;
        private readonly ILoggerService _logger;
        private readonly INotificationService _notifier;

        private HexData[] _hexDatas = [];
        private bool _initialized = false;

        public MapsWatcherTask(
            FoxholeApiClient foxhole,
            ILoggerService logger,
            INotificationService notifier)
        {
            _foxhole = foxhole ?? throw new ArgumentNullException(nameof(foxhole));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
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

        // ---------------- INIT ----------------

        private async Task InitializeAsync()
        {
            var maps = await _foxhole.GetMapsAsync();
            if (maps == null || maps.Length == 0)
                throw new Exception("No maps found from Foxhole API.");

            _hexDatas = new HexData[maps.Length];

            _logger.Info("Start initializing hex data...");
            DrawProgressBar(0, maps.Length);

            for (int i = 0; i < maps.Length; i++)
            {
                try
                {
                    var mapData = await _foxhole.GetDynamicMapDataAsync(maps[i]);
                    var bases = ExtractBases(mapData);

                    _hexDatas[i] = new HexData(maps[i], bases);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Failed to get initial data for hex {maps[i]}", ex);
                    _hexDatas[i] = new HexData(maps[i], Enumerable.Empty<BaseInfo>());
                }

                DrawProgressBar(i + 1, maps.Length);
            }

            Console.WriteLine();
            _logger.Info($"Initialized {_hexDatas.Length} hexes");
        }

        // ---------------- UPDATE ----------------

        private async Task UpdateAsync()
        {
            bool dataUpdateCorrect = true;
            List<string> errorUpdateHexNames = new();

            using SemaphoreSlim semaphore = new SemaphoreSlim(5);

            var tasks = _hexDatas.Select(async hex =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var freshData = await _foxhole.GetDynamicMapDataAsync(hex.HexName);
                    var bases = ExtractBases(freshData);

                    bool colonialLost = hex.HasLostBase("COLONIALS", bases);

                    if (colonialLost)
                    {
                        string msg = $"💀 One of the bases in {hex.HexName} was lost.";
                        _logger.Info(msg);
                        await _notifier.SendMessageAsync(msg);
                    }
                }
                catch (Exception ex)
                {
                    dataUpdateCorrect = false;
                    errorUpdateHexNames.Add(hex.HexName);
                    _logger.Error($"Failed to update hex {hex.HexName}", ex);
                }
                finally
                {
                    semaphore.Release();
                }
            });

            await Task.WhenAll(tasks);

            if (dataUpdateCorrect)
            {
                _logger.Info($"Map data updated at {DateTime.Now}");
            }
            else
            {
                _logger.Warning($"Failed to update hex(s): {string.Join(", ", errorUpdateHexNames)}");
            }
        }

        // ---------------- HELPERS ----------------

        private static IEnumerable<BaseInfo> ExtractBases(MapResponse data)
        {
            var validIconTypes = new HashSet<int> { 45, 56, 57, 58 };

            foreach (var item in data.MapItems)
            {
                if (!validIconTypes.Contains(item.IconType))
                    continue;

                yield return new BaseInfo
                {
                    BaseId = HexData.BuildBaseId(item.X, item.Y),
                    TeamId = item.TeamId
                };
            }
        }

        private void DrawProgressBar(int current, int total, int barSize = 30)
        {
            double progress = (double)current / total;
            int filled = (int)(progress * barSize);

            Console.CursorLeft = 0;
            Console.Write("[");
            Console.Write(new string('█', filled));
            Console.Write(new string('-', barSize - filled));
            Console.Write($"] {current}/{total}");
        }
    }
}
