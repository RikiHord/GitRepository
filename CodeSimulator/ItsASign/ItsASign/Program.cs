namespace ItsASign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> singNames = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                string? yourName = Console.ReadLine();
                if (string.IsNullOrEmpty(yourName))
                {
                    Console.WriteLine("Invalid name.");
                    return;
                }
                else
                {
                    singNames.Add(yourName.ToUpper());
                }
            }

            if (CheckClass.CheckPalindrom(singNames))
            {
                Console.WriteLine("Open");
            }
            else
            {
                Console.WriteLine("Trash");
            }
        }
    }
}
