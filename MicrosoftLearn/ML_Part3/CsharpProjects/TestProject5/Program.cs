// Task 1
// Random random = new Random();
// int heroHP = 10;
// int monsterHP = 10;

// do
// {
//     int heroDamage = random.Next(10);
//     monsterHP -= heroDamage;
//     Console.WriteLine($"Monster was damaged and lost {heroDamage} health and now has {monsterHP} health.");

//     if (monsterHP > 0)
//     {
//         int monsterDamage = random.Next(10);
//         heroHP -= monsterDamage;
//         Console.WriteLine($"Hero was damaged and lost {monsterDamage} health and now has {heroHP} health.");
//     }
// } while (heroHP > 0 && monsterHP > 0);

// Console.WriteLine($"{(heroHP > 0? "Hero wins!" : "Hero loses!")}");

//Task 2
// Console.WriteLine("Enter an integer value between 5 and 10");

// bool validInput;
// do
// {
//     validInput = false;
//     int inputNumber;

//     validInput = int.TryParse(Console.ReadLine(), out inputNumber);

//     if (!validInput)
//     {
//         Console.WriteLine("Sorry, you entered an invalid number, please try again");
//         continue;
//     }

//     if (inputNumber < 5 || inputNumber > 10)
//     {
//         Console.WriteLine($"You entered {inputNumber}. Please enter a number between 5 and 10.");
//         validInput = false;
//         continue;
//     }

//     Console.WriteLine($"Your input value ({inputNumber}) has been accepted.");
// }while(!validInput);

//Task 3
// bool correctInputRole = false;
// string[] correctRoleName = ["administrator", "manager", "user"];
// do{
//     Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

//     string? inputRole = Console.ReadLine();
//     if (string.IsNullOrEmpty(inputRole))
//         continue;

//     if (!correctRoleName.Contains(inputRole.Trim().ToLower()))
//     {
//         Console.Write($"The role name that you entered, \"{inputRole}\" is not valid. ");
//         continue;
//     }
//     correctInputRole = true;
//     Console.WriteLine($"Your input value ({inputRole}) has been accepted.");
// }while(!correctInputRole);

//Task 4
string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation;

foreach(string myString in myStrings)
{
    periodLocation = myString.IndexOf(".");
    if (periodLocation != -1)
    {
        string tempMyString = myString;
        while(periodLocation != -1)
        {
            Console.WriteLine(tempMyString.Substring(0, periodLocation));
            tempMyString = tempMyString.Remove(0, periodLocation+2);
            periodLocation = tempMyString.IndexOf(".");
            if (periodLocation == -1)
                Console.WriteLine(tempMyString);
        }
    }
    else
    {
        Console.WriteLine(myString);
    }
}