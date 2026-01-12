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
        public AppSettings Settings { get; }

        public ConfigService(string path = "appsettings.json")
        {
            var jsonText = File.ReadAllText(path);
            Settings = JsonSerializer.Deserialize<AppSettings>(jsonText)
                       ?? throw new Exception("Failed to read appsettings.json");
        }
    }
}
