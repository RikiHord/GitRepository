using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resize_Project
{
    class Program
    {
        /// <summary>
        /// Resize array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="newSize"></param>
        static void Resize<T>(ref T[] array, uint newSize)
        {
            T[] newArray = new T[newSize];

            for (int i = 0; i < newArray.Length && i < array?.Length; i++)
                newArray[i] = array[i];

            array = newArray;
        }

        
        static void Main(string[] args)
        {
            int[] arr = null;
            Resize(ref arr, 10);

            Console.WriteLine("Сумма елементов масива = " + (arr?.Sum() ?? 0));

            string nullString = null;
            Console.WriteLine(nullString ??= "no data");
            Console.WriteLine(nullString);

        }
    }
}
