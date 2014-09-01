using System;
using System.Text.RegularExpressions;

// Write a program to find the longest word in a text.

class LongestWordInText
{
    static void Main()
    {
        Console.WriteLine("Please enter the text below:");
        string text = Console.ReadLine();

        string[] words = Regex.Split(text, @"\W");

        int longestWordLength = 0;
        string longestWord = null;

        foreach (var word in words)
        {
            int length = word.Length;            

            if (length > longestWordLength)
            {
                longestWord = word;
                longestWordLength = length;
            }
        }

        Console.WriteLine("\nThe longest word in the text is:\n{0} ({1} characters long)\n", longestWord, longestWordLength);
    }
}
