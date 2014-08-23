using System;
using System.Globalization;

// Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. 

class DifferenceBetweenDates
{
    static void Main()
    {
        IFormatProvider culture = new CultureInfo("bg-BG", true);
        Console.WriteLine("Enter two dates to find how many days are between them.\n");

        Console.Write("First date (dd.MM.yyyy): ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine(), culture);

        Console.Write("Second date (dd.MM.yyyy): ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine(), culture);

        TimeSpan difference = secondDate - firstDate;
        Console.WriteLine("\nResult:\n{0} days\n", difference.Days);        
    }
}
