using FoxholeWatcher.Discord;
using FoxholeWatcher.Foxhole;
using FoxholeWatcher.Runners;
using FoxholeWatcher.Tasks;

namespace FoxholeWatcher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MapsWatcherTask mapsWatcherTask = new MapsWatcherTask(
                new FoxholeApiClient()
                );

            while (true)
            {
                await mapsWatcherTask.ExecuteAsync();
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }
    }
}
