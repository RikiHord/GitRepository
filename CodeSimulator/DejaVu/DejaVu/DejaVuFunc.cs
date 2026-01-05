using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DejaVu
{
    public class DejaVuFunc
    {
        public static string CheckDejaVu(string input)
        {
            input = input.Replace(" ", "");
            HashSet<char> seenChars = new HashSet<char>();
            foreach (char c in input)
            {
                if (seenChars.Contains(c))
                {
                    return "Deja Vu";
                }
                seenChars.Add(c);
            }
            return "Unique";
        }
    }
}
