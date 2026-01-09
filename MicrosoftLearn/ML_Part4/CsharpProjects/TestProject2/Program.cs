// string pangram = "The quick brown fox jumps over the lazy dog";

// string[] splitPangram = pangram.Split(" ");

// for (int i = 0; i < splitPangram.Length; i++)
// {
//     char[] letters = splitPangram[i].ToCharArray();
//     Array.Reverse(letters);
//     splitPangram[i] = new string(letters);
// }

// Console.WriteLine(String.Join(" ", splitPangram));

string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

string [] orders = orderStream.Split(",");
Array.Sort(orders);

foreach(string order in orders)
{
    string output = order;
    if (output.Length != 4)
        output += "\t - Error";
    Console.WriteLine(output);
}