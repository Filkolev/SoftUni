using System;
using System.Text.RegularExpressions;

/* Write a program that extracts and prints all URLs from given text. URL can be in only two formats:
•	http://something, e.g. http://softuni.bg, http://forums.softuni.bg, http://www.nakov.com 
•	www.something.domain, e.g. www.nakov.com, www.softuni.bg, www.google.com  */

class ExtractURLs
{
    static void Main()
    {
        Console.WriteLine("Please enter the text below:");
        string input = Console.ReadLine();

        Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Console.WriteLine("\nAll URLs matching the criteria:");
        foreach(Match m in linkParser.Matches(input))
        {
            Console.WriteLine(m);
        }

        Console.WriteLine();
    }
}
