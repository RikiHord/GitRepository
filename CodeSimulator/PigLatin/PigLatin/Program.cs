namespace PigLatin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No valid data");
                return;
            }

            string output = Converter.ToPigLatin(input);
            Console.WriteLine(output);
        }
    }
}
