using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insetrion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] InsertionSort(int[] arr)
            {
                for (int i = 1; i < arr.Length; i++){
                    for (int j = i; j > 0 && arr[j] < arr[j - 1]; j--){
                         var temp = arr[j];
                         arr[j] = arr[j - 1];
                         arr[j - 1] = temp;
                    }
                }
                return arr;
            }

            int[] array = { 5, 2, 6, 8, 1, 5, 10, 2 };
            int[] sortArray = InsertionSort(array);

            foreach (var item in sortArray)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
