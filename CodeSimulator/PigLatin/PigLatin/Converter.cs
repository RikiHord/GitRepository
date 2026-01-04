using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    public class Converter
    {
        private static string ConvertWordToPigLatin(string word)
        {
            if (string.IsNullOrEmpty(word))
                return word;
            char firstChar = word[0];
            bool isUpper = char.IsUpper(firstChar);
            string lowerWord = word.ToLower();
            string pigLatinWord;
            if ("aeiou".Contains(lowerWord[0]))
            {
                pigLatinWord = lowerWord + "way";
            }
            else
            {
                int vowelIndex = -1;
                for (int i = 0; i < lowerWord.Length; i++)
                {
                    if ("aeiou".Contains(lowerWord[i]))
                    {
                        vowelIndex = i;
                        break;
                    }
                }
                if (vowelIndex == -1)
                {
                    pigLatinWord = lowerWord + "ay";
                }
                else
                {
                    pigLatinWord = lowerWord.Substring(vowelIndex) + lowerWord.Substring(0, vowelIndex) + "ay";
                }
            }
            if (isUpper)
            {
                pigLatinWord = char.ToUpper(pigLatinWord[0]) + pigLatinWord.Substring(1);
            }
            return pigLatinWord;
        }
        public static string ToPigLatin(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            var words = input.Split(' ');
            var pigLatinWords = words.Select(word => ConvertWordToPigLatin(word));
            return string.Join(" ", pigLatinWords);
        }
    }
}
