Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay())
{
    PlayGame();
}

bool ShouldPlay()
{
    bool correctInput = false;
    string? input;
    do
    {
        input = Console.ReadLine();
        if (input != null && (input.ToLower() == "y" || input.ToLower() == "n"))
            correctInput = true;
        else
            Console.WriteLine("Invalid input. Plese print Y or N");
    } while (!correctInput);

    return input == "y";
}

string WinOrLose(int target, int roll)
{
    return $"{(target < roll ? "You Win!" : "You lose!")}";
}

void PlayGame()
{
    var play = true;

    while (play)
    {
        var target = random.Next(1, 6);
        var roll = random.Next(1, 7);

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(target, roll));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();
    }
}