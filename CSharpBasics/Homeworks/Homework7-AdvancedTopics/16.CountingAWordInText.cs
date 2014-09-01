using System;
using System.Text.RegularExpressions;
//using System.IO;

/* Write a program that counts how many times a given word occurs in given text. The first line in the 
 input holds the word. The second line of the input holds the text. The output should be a single integer 
 number – the number of word occurrences. Matching should be case-insensitive. Note that not all matching 
 substrings are words and should be counted. A word is a sequence of letters separated by punctuation or 
 start / end of text. */

class CountingAWordInText
{
    static void Main()
    {
        Console.Write("Enter the word you would like to count: ");
        string lookupWord = Console.ReadLine();
        Console.WriteLine("\nPlease enter the text below:");
        string text = Console.ReadLine();

        //string text = null;
        //using (StreamReader sr = new StreamReader("CountWordInText.txt"))
        //{
        //    text = sr.ReadToEnd();           
        //}

        string[] words = Regex.Split(text, @"\W"); 

        int count = 0;

        foreach (var word in words)
        {
            if (word.Equals(lookupWord, StringComparison.InvariantCultureIgnoreCase))
            {
                count++;
            }            
        }

        Console.WriteLine("\nThe text contains the word \"{0}\" {1} times.\n", lookupWord, count);
    }
}
