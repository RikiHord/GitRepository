using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Foxhole.Class
{
    public class HexData
    {
        public string HexName { get; }
        public IReadOnlyList<string> TeamIds { get; private set; }

        public HexData(string hexName, IEnumerable<string> teamIds)
        {
            HexName = hexName;
            TeamIds = teamIds.ToList();
        }

        // Update TeamIds
        public void SetTeamIds(IEnumerable<string> newTeamIds)
        {
            TeamIds = newTeamIds.ToList();
        }

        // Method for checking changes for any command
        public bool HasLostBase(string team, IEnumerable<string> newTeamIds)
        {
            var newList = newTeamIds.ToList();
            for (int i = 0; i < Math.Min(TeamIds.Count, newList.Count); i++)
            {
                if (TeamIds[i] == team && newList[i] != team)
                    return true;
            }
            return false;
        }
    }
}
