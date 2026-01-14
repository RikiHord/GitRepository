using FoxholeWatcher.Foxhole.Class;
using FoxholeWatcher.Foxhole.Models;
using System.Text.Json;

namespace FoxholeWatcher.Foxhole
{
    public class FoxholeApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public FoxholeApiClient(){}

        private async Task<T> GetAndDeserializeAsync<T>(string url)
        {
            var response = await _httpClient.GetStringAsync(url);
            if (string.IsNullOrWhiteSpace(response))
                throw new HttpRequestException($"Empty response from {url}");

            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }

        public async Task<WarInfo?> GetWarInfoAsync()
        {
            // Get data about current war
            return await GetAndDeserializeAsync<WarInfo>(
                "https://war-service-live.foxholeservices.com/api/worldconquest/war"
            );
        }

        public async Task<string[]> GetMapsAsync()
        {
            // Get available hex names
            return await GetAndDeserializeAsync<string[]>(
                "https://war-service-live.foxholeservices.com/api/worldconquest/maps"
            );
        }

        public async Task<MapResponse> GetDynamicMapDataAsync(string hexName)
        {
            return await GetAndDeserializeAsync<MapResponse>(
                $"https://war-service-live.foxholeservices.com/api/worldconquest/maps/{hexName}/dynamic/public"
            );
        }
    }
}
