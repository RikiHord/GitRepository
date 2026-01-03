using System;

namespace ConsoleQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = null;
            Console.WriteLine("Input N");
            int N = int.Parse(Console.ReadLine());
            GenerateArray(ref array, N);

            PrintArray(ref array);

            int[] sortedArray = QuickSort(array, 0, array.Length - 1);
            Console.WriteLine();

            PrintArray(ref sortedArray);
        }

        private static void GenerateArray(ref int[] array, int N)
        {
            array = new int[N];
            var random = new Random();

            for (int i = 0; i < N - 1; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }

        private static void PrintArray(ref int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        private static int Pivot(ref int[] array, int minValue, int maxValue)
        {
            int pivot = minValue - 1;
            for (int i = minValue; i < maxValue; i++)
            {
                if(array[i] < array[maxValue])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxValue]);
            return pivot;
        }

        private static int[] QuickSort(int[] array, int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                return array;

            int pivot = Pivot(ref array, minValue, maxValue);
            QuickSort(array, minValue, pivot - 1);
            QuickSort(array, pivot + 1, maxValue);

            return array;
        }
    }
}
