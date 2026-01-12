using FoxholeWatcher.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Services
{
    public interface IConfigService
    {
        AppSettings Settings { get; }
    }
}
