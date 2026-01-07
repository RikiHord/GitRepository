/*
    Reverse string message and count char 'o'
*/
string str = "The quick brown fox jumps over the lazy dog.";

char[] charMessage = str.ToCharArray();
Array.Reverse(charMessage);

int countCharO = 0;

foreach (char i in charMessage) 
{ 
    if (i == 'o') 
    { 
        countCharO++; 
    } 
}

string newMessage = new String(charMessage);

Console.WriteLine(newMessage);
Console.WriteLine($"'o' appears {countCharO} times.");