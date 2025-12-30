using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sequrity
{
    public class CheckFloor
    {
        public static bool IsFloorSafe(string input)
        {
            string pattern = @"^(?!.*\$[^G]*T)(?!.*T[^G]*\$).*";

            return Regex.IsMatch(input, pattern);
        }
    }
}
