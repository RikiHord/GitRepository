namespace NewDriversLicense
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? yourName = Console.ReadLine();
            if (string.IsNullOrEmpty(yourName)){
                Console.WriteLine("Invalid name.");
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out int countOfAgents)){
                Console.WriteLine("Invalid number of agents.");
                return;
            }

            string? namesOfPeople = Console.ReadLine();
            if (string.IsNullOrEmpty(namesOfPeople)){
                Console.WriteLine("Invalid names of people.");
                return;
            }

            Console.WriteLine(new CalcTimeForGetNewLicense().CalculateTotalTime(yourName, countOfAgents, namesOfPeople));
        }
    }
}
