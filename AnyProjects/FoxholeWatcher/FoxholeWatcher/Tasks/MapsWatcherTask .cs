using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Foxhole.Class;
using FoxholeWatcher.Foxhole.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace FoxholeWatcher.Tasks
{
    public class MapsWatcherTask: IFoxholeTask
    {
        private readonly FoxholeApiClient _foxhole;

        private HexData[] _hexDatas = [];
        private bool _initialized = false;

        public MapsWatcherTask(FoxholeApiClient foxhole)
        {
            _foxhole = foxhole;
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
            var maps = await _foxhole.GetMapsAsync();

            if (maps == null || maps.mapNames.Length == 0)
                throw new Exception("No maps found from Foxhole API.");

            _hexDatas = new HexData[maps.mapNames.Length];

            for (int i = 0; i < maps.mapNames.Length; i++)
            {
                _hexDatas[i] =
                    await _foxhole.GetDynamicMapDataAsync(maps.mapNames[i]);
            }

            Console.WriteLine($"Initialized {_hexDatas.Length} hexes");
        }

        private async Task UpdateAsync()
        {
            foreach (var hex in _hexDatas)
            {
                var freshData =
                    await _foxhole.GetDynamicMapDataAsync(hex.HexName);

                var changed = hex.Update(freshData.TeamIds);

                if (changed)
                {
                    Console.WriteLine(
                        $"Hex {hex.HexName} colonial lost base!"
                    );

                    // TODO: Discord notify
                    var jsonText = await File.ReadAllTextAsync("appsettings.json");
                    using JsonDocument doc = JsonDocument.Parse(jsonText);
                    string webhookUrl = doc.RootElement
                                            .GetProperty("Discord")
                                            .GetProperty("WebhookUrl")
                                            .GetString()!;

                    Discord.DiscordWebhookClient _discord =
                        new Discord.DiscordWebhookClient(
                            webhookUrl
                        );
                    await _discord.SendMessageAsync(
                        $"Hex {hex.HexName} colonial lost base!"
                        );
                }
            }
            Console.WriteLine($"Last update {DateTime.Now}");
        }
    }
}
