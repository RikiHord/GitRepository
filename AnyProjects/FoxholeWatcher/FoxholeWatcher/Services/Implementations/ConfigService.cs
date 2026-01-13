using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoxholeWatcher.Services.Implementations
{
    public class ConfigService : IConfigService
    {
        const int MIN_INTERVAL = 10;
        const int MAX_INTERVAL = 60 * 60;

        public AppSettings Settings { get; }

        public ConfigService(string path, ILoggerService logger)
        {
            Settings = Load(path);
            Normalize(Settings, logger);
        }

        private static AppSettings Load(string path)
        {
            if (!File.Exists(path))
                throw new Exception($"Config file not found: {path}");

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<AppSettings>(json)
                   ?? throw new Exception("Failed to load AppSettings");
        }

        private static void Normalize(AppSettings settings, ILoggerService logger)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.Discord.WebhookUrl))
                throw new Exception("Discord:WebhookUrl is missing or empty");

            int? rawInterval = settings.App.TimespanInSeconds;

            if (!rawInterval.HasValue)
            {
                settings.App.TimespanInSeconds = MIN_INTERVAL;

                logger.Warning(
                    "App:TimespanInSeconds was not found or could not be parsed. " +
                    $"Using default value {MIN_INTERVAL} seconds."
                );

                return;
            }

            if (rawInterval.Value < MIN_INTERVAL || rawInterval.Value > MAX_INTERVAL)
            {
                settings.App.TimespanInSeconds = MIN_INTERVAL;

                logger.Warning(
                    $"App:TimespanInSeconds value {rawInterval.Value} is out of range " +
                    $"({MIN_INTERVAL}–{MAX_INTERVAL}). Using default value {MIN_INTERVAL} seconds."
                );

                return;
            }

            settings.App.TimespanInSeconds = rawInterval.Value;
        }
    }
}
