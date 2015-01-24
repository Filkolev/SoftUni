using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/175

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());

        string[] time = Console.ReadLine().Split(':');
        int hour = int.Parse(time[0]);

        int totalFlats = floors * flats;

        double result = 0;

        if (hour >= 14 && hour <= 18)
        {
            result = 2 * totalFlats * 100.53 + 2 * totalFlats * 125.90;
        }

        else if (hour >= 19 && hour <= 23)
        {
            result = 7 * totalFlats * 100.53 + 6 * totalFlats * 125.90;
        }

        else if (hour >= 0 && hour <= 8)
        {
            result = 1 * totalFlats * 100.53 + 8 * totalFlats * 125.90;
        }

        Console.WriteLine("{0} Watts", (int)result);
    }
}
