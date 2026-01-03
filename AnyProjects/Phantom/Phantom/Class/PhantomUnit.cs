using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.Class
{
    public class PhantomUnit
    {

        public int Id { get; set; }
        public string Path { get; set; }
        public string Password { get; set; }

        public string PhantomUnitPath
        {
            get
            {
                return $"{Path}";
            }
        }
    }
}
