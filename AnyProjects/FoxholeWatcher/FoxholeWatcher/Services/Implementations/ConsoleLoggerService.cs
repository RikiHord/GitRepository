using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Services.Implementations
{
    public class ConsoleLoggerService : ILoggerService
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }
        public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] {message}");
            Console.ResetColor();
        }
        public void Error(string message, Exception? ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            if (ex != null)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ResetColor();
        }
    }
}
