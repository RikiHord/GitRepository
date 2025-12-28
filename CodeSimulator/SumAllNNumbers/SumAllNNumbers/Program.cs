namespace SumAllNNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
            List<double> dNumbers = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            List<string> strings = new List<string>() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            List<bool> signals = new List<bool>() {false, true, true, false};

            int nForSum = 2;

            Console.WriteLine(Calc<int>.CalcSumAllNNumbers(numbers, nForSum));


        }
    }
}
