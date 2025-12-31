namespace _2DMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Map map = new Map(input);
            int moves = map.GetCountMovesBetweenTwoP();
            Console.WriteLine(moves);
        }
    }
}
