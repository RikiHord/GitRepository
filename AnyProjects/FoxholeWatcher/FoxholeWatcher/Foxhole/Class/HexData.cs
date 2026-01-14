using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Foxhole.Class
{
    public class BaseInfo
    {
        public string BaseId { get; init; } = string.Empty;
        public string TeamId { get; init; } = string.Empty;
    }
    public class HexData
    {
        public string HexName { get; }
        private Dictionary<string, string> _bases = new();

        public HexData(string hexName, IEnumerable<BaseInfo> initialBases)
        {
            HexName = hexName;
            _bases = initialBases.ToDictionary(b => b.BaseId, b => b.TeamId);
        }

        public static string BuildBaseId(double x, double y)
        {
            return $"{Math.Round(x, 5)}:{Math.Round(y, 5)}";
        }

        /// <summary>
        /// Method for checking changes for any command
        /// </summary>
        public bool HasLostBase(string team, IEnumerable<BaseInfo> newBases)
        {
            var newDict = newBases.ToDictionary(b => b.BaseId, b => b.TeamId);

            foreach (var (baseId, oldTeam) in _bases)
            {
                if (oldTeam != team)
                    continue;

                if (!newDict.TryGetValue(baseId, out var newTeam) || newTeam != team)
                {
                    _bases = newDict;
                    return true;
                }
            }

            _bases = newDict;
            return false;
        }
    }
}
