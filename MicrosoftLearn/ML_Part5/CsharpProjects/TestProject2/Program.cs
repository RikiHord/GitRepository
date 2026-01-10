string[,] corporate = 
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external = 
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

for (int i = 0; i < corporate.GetLength(0); i++) 
{
    DisplayEmail(corporate[i, 0], corporate[i, 1]);
}

for (int i = 0; i < external.GetLength(0); i++) 
{
    DisplayEmail(external[i, 0], external[i, 1], externalDomain);
}

void DisplayEmail(string firstname, string lastname, string domain = "contoso.com")
{
    string emailName = firstname.Substring(0, 2).ToLower() + lastname.ToLower();
    string email = $"{emailName}@{domain}";
    Console.WriteLine(email);
}