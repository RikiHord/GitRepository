using FoxholeWatcher.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Runners
{
    public class FoxholeRunner
    {
        public async Task RunAsync(params IFoxholeTask[] tasks)
        {
            foreach (var task in tasks)
            {
                await task.ExecuteAsync();
            }
        }
    }
}
