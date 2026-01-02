using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsOfPI
{
    public class MainPI
    {
        public static int IndexOfPI(int n)
        {
            int maxDigits = 1000;
            int len = (10 * maxDigits) / 3;
            List<int> newPi = new List<int>();

            int[] a = new int[len + 1];
            int nines = 0;
            int predigit = 0;

            for (int j = 1; j <= len; j++)
                a[j] = 2;

            for (int j = 1; j <= maxDigits; j++)
            {
                int q = 0;

                for (int i = len; i >= 1; i--)
                {
                    int x = 10 * a[i] + q * i;
                    a[i] = x % (2 * i - 1);
                    q = x / (2 * i - 1);
                }

                a[1] = q % 10;
                q /= 10;

                if (q == 9)
                {
                    nines++;
                }
                else if (q == 10)
                {
                    newPi.Add(predigit + 1);

                    for (int k = 1; k <= nines; k++)
                        newPi.Add(0);

                    predigit = 0;
                    nines = 0;
                }
                else
                {
                    if (j > 1)
                        newPi.Add(predigit);

                    predigit = q;

                    if (nines != 0)
                    {
                        for (int k = 1; k <= nines; k++)
                            newPi.Add(9);

                        nines = 0;
                    }
                }
            }

            return newPi[n];
        }
    }
}
