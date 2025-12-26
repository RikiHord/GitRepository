namespace Popsicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!int.TryParse(Console.ReadLine(), out int numberOfSiblings))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out int numberOfIceCream))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                return;
            }

            Console.WriteLine(CalcPotrion.GivePortionOrNot(numberOfSiblings, numberOfIceCream));
        }
    }
}
