namespace Thats_Odd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            if (!int.TryParse(Console.ReadLine(), out int sizeList))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                return;
            }

            for (int i = 0; i < sizeList; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    return;
                }

                numbers.Add(value);
            }

            int sum = EvenSumCalculator.SumEvenNumbers(numbers);
            Console.WriteLine("Sum odd: " + sum);
        }
    }
}
