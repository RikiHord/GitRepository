using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -1, -4, -6, -13, -23, -2, -2, -9 };

            int[] arr2 = arr.Where(i => i >= 0).ToArray();

            if(arr2.Length != 0)
                foreach (var item in arr2)
                    Console.Write(item + " ");
            else
                Console.WriteLine("None unsigned");

        }
    }
}
