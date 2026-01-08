for (int i = 1; i <= 100; i++)
{
    Console.Write(i);
    string fizzbuzz = " - ";
    if (i % 3 == 0)
        fizzbuzz += "Fizz";
    if (i % 5 == 0)
        fizzbuzz += "Buzz";

    if (fizzbuzz.Length > 3)
        Console.Write(fizzbuzz);

    Console.WriteLine();
}