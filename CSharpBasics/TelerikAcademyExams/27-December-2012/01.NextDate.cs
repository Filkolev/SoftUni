using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/262

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime today = new DateTime(year, month, day);
        DateTime result = today.AddDays(1);

        Console.WriteLine("{0}.{1}.{2}", result.Day, result.Month, result.Year);
    }
}
