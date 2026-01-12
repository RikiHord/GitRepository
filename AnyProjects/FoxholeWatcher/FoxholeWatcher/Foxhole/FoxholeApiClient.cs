using FoxholeWatcher.Foxhole.Class;
using FoxholeWatcher.Foxhole.Models;
using System.Text.Json;

namespace FoxholeWatcher.Foxhole
{
    public class FoxholeApiClient
    {
        private readonly HttpClient _httpClient;

        public FoxholeApiClient(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

        public async Task<WarInfo?> GetWarInfoAsync()
        {
            var response = await _httpClient.GetStringAsync(
                "https://war-service-live.foxholeservices.com/api/worldconquest/war"
            );

            if (string.IsNullOrWhiteSpace(response))
            {
                throw new HttpRequestException("Received empty response from Foxhole API.");
            }

            return JsonSerializer.Deserialize<WarInfo>(
                response,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            )!;
        }

        public async Task<Maps?> GetMapsAsync()
        {
            var response = await _httpClient.GetStringAsync(
                "https://war-service-live.foxholeservices.com/api/worldconquest/maps"
            );
            if (string.IsNullOrWhiteSpace(response))
            {
                throw new HttpRequestException("Received empty response from Foxhole API.");
            }

            var maps = new Maps(
                JsonSerializer.Deserialize<string[]>(response)!
            );

            return maps;
        }

        public async Task<HexData> GetDynamicMapDataAsync(string hexName)
        {
            var response = await _httpClient.GetStringAsync(
                $"https://war-service-live.foxholeservices.com/api/worldconquest/maps/{hexName}/dynamic/public"
            );
            if (string.IsNullOrWhiteSpace(response))
            {
                throw new HttpRequestException("Received empty response from Foxhole API.");
            }

            var data = JsonSerializer.Deserialize<MapResponse>(
                response, 
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            )!;

            var validIconTypes = new HashSet<int> { 45, 56, 57, 58 };

            var teamIds = data.MapItems
                .Where(i => validIconTypes.Contains(i.IconType))
                .Select(i => i.TeamId)
                .ToList();

            return new HexData(hexName, teamIds);
        }
    }
}
