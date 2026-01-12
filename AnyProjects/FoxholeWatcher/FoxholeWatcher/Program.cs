using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Runners;
using FoxholeWatcher.Services;
using FoxholeWatcher.Services.Implementations;
using FoxholeWatcher.Tasks;
using System.Text.Json;

namespace FoxholeWatcher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfigService config = new ConfigService("appsettings.json");

            // Get Discord webhook URL from config
            string webhookUrl = config.Settings.Discord.WebhookUrl;

            var discordClient = new DiscordWebhookClient(webhookUrl);
            ILoggerService logger = new ConsoleLoggerService();
            INotificationService notifier = new DiscordNotificationService(discordClient, logger);

            var mapsWatcherTask = new MapsWatcherTask(
                new FoxholeApiClient(),
                logger,
                notifier
            );

            while (true)
            {
                await mapsWatcherTask.ExecuteAsync();
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}
