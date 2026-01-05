using System;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DejaVu
{
    internal class Program
    {
        /*Task:  
        If you are given a string of random letters, your task is to evaluate whether any letter is repeated in the string or if you only hit unique keys while you typing.

        Input Format:  
        A string of random letter characters (no numbers or other buttons were pressed). 
 
        Output Format:  
        A string that says 'Deja Vu' if any letter is repeated in the input string, or a string that says 'Unique' if there are no repeats.*/
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No valid data");
                return;
            }

            Console.WriteLine(DejaVuFunc.CheckDejaVu(input));
        }
    }
}
