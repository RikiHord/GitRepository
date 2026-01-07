using System.Security.Permissions;

string[] codes = ["B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"];

foreach (string code in codes)
{
    if (code.StartsWith("B"))
    {
        Console.WriteLine(code);
    }
}