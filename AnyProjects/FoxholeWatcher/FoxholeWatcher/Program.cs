using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Services;
using FoxholeWatcher.Services.Implementations;
using FoxholeWatcher.Tasks;

namespace FoxholeWatcher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ILoggerService logger = new ConsoleLoggerService();
            IConfigService config = null;
            try
            {
                config = new ConfigService("appsettings.json", logger);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
                return;
            }

            string webhookUrl = config.Settings.Discord.WebhookUrl;
            int timeoutSeconds = config.Settings.App.TimespanInSeconds;

            // Get Discord webhook URL from config

            var discordClient = new DiscordWebhookClient(webhookUrl);
            INotificationService notifier = new DiscordNotificationService(discordClient, logger);

            var mapsWatcherTask = new MapsWatcherTask(
                new FoxholeApiClient(),
                logger,
                notifier
            );

            while (true)
            {
                await mapsWatcherTask.ExecuteAsync();
                await Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));
            }
        }
    }
}
