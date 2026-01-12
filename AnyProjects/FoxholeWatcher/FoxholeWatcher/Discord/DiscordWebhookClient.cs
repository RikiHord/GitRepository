using System.Text;
using System.Text.Json;

namespace FoxholeWatcher.Discord
{
    public class DiscordWebhookClient
    {
        private readonly string _webhookUrl;
        private readonly HttpClient _httpClient = new();

        public DiscordWebhookClient(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task SendMessageAsync(string message)
        {
            var payload = new { content = message };
            var json = JsonSerializer.Serialize(payload);

            await _httpClient.PostAsync(
                _webhookUrl,
                new StringContent(json, Encoding.UTF8, "application/json")
            );
        }
    }
}
