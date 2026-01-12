using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Services
{
    public interface INotificationService
    {
        Task SendMessageAsync(string message);
    }
}
