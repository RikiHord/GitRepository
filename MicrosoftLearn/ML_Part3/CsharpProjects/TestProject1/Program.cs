// Random random = new();
// string coinSide = random.Next(2) == 0? "heards" : "tails";
// Console.WriteLine(coinSide);

string permission = "Admin|Manager";
int level = 56;

if (permission.Contains("Admin"))
{
    Console.WriteLine($"Welcome, {(level > 55 ? "Super " : "")}Admin user.");
}
else if (permission.Contains("Manager"))
{
    Console.WriteLine($"{(level >= 20 ? "Contact an Admin for access." : "You do not have sufficient privileges.")}");
}
else
{
    Console.WriteLine("You do not have sufficient privileges.");
}