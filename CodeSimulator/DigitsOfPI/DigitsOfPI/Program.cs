namespace DigitsOfPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Console.ReadLine() is string input && int.TryParse(input, out int value) ? value : 0;

            if (n < 0 || n > 1000)
            {
                Console.WriteLine("Please enter a number between 0 and 1000.");
                return;
            }

            Console.WriteLine(MainPI.IndexOfPI(n));
        }
    }
}
