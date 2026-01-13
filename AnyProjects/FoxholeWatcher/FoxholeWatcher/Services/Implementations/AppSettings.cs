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
        public ApplicationSettings App { get; set; } = new();
    }

    public class DiscordSettings
    {
        public string WebhookUrl { get; set; } = "";
    }

    public class ApplicationSettings
    {
        public int TimespanInSeconds { get; set;  }
    }
}
