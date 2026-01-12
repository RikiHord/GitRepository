using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Services.Implementations
{
    public class AppSettings
    {
        public DiscordSettings Discord { get; set; } = new();
    }

    public class DiscordSettings
    {
        public string WebhookUrl { get; set; } = "";
    }
}
