using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefFunc
{
    class Program
    {
        static ref int Func(int[] array, uint index)
        {
            return ref array[index];
        }
        static void Main(string[] args)
        {
            int[] arr = null;

            ref int value = ref Func(arr, 3);

            value = 99;

            Console.WriteLine(arr[0]);
        }
    }
}
