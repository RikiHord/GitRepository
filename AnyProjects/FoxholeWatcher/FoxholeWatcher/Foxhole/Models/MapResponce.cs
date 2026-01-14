using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxholeWatcher.Foxhole.Models
{
    public class MapResponse
    {
        public List<MapItem> MapItems { get; set; } = [];
    }

    public class MapItem
    {
        public string TeamId { get; set; } = "";
        public int IconType { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
