using FoxholeWatcher.Discord;

namespace FoxholeWatcher.Services.Implementations
{
    public class DiscordNotificationService : INotificationService
    {
        private readonly DiscordWebhookClient _discord;
        private readonly ILoggerService _logger;

        public DiscordNotificationService(DiscordWebhookClient discord, ILoggerService logger)
        {
            _discord = discord;
            _logger = logger;
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                await _discord.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to send Discord message", ex);
            }
        }
    }
}
