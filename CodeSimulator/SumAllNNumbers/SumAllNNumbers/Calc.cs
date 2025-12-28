using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SumAllNNumbers
{
    public class Calc<T> where T : INumber<T>
    {
        public static T CalcSumAllNNumbers(List<T> listV, int nForSum) {
            if (   nForSum <= 0 
                || listV == null 
                || listV.Count < nForSum) 
                return T.Zero;

            dynamic sum = T.Zero;

            for (int i = nForSum - 1; i < listV.Count; i += nForSum)
            {
                sum += listV[i];
            }

            return sum;

        }
    }
}
