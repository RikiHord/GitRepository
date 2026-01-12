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

        public bool Update(IEnumerable<string> newTeamIds)
        {
            var newList = newTeamIds.ToList();
            List<string> changes = new List<string>();

            // TODO: Переделать
            for (int i = 0; i < TeamIds.Count; i++)
            {
                if (TeamIds[i] == "COLONIAL" && newList[i] != "COLONIAL")
                {
                    TeamIds = newList;
                    return true;
                }
            }

            TeamIds = newList;
            return false;
        }
    }
}
