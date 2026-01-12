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

        public async Task<HexData> GetDynamicMapDataAsync(string hexName)
        {
            //Get dynamic data for a specific hex
            var data = await GetAndDeserializeAsync<MapResponse>(
                $"https://war-service-live.foxholeservices.com/api/worldconquest/maps/{hexName}/dynamic/public"
            );

            // Filter IconType
            var validIconTypes = new HashSet<int> { 45, 56, 57, 58 };

            var teamIds = data.MapItems
                .Where(i => validIconTypes.Contains(i.IconType))
                .Select(i => i.TeamId)
                .ToList();

            return new HexData(hexName, teamIds);
        }
    }
}
