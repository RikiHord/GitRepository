using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Great_Town.Class
{
    class TypeArea
    {

        private string name;
        private Color color;

        public TypeArea() { }

        public TypeArea(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }

        }
    }
}
