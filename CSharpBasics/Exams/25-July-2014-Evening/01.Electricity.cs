using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/175

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());

        DateTime hour = DateTime.Parse(Console.ReadLine());

        int totalFlats = floors * flats;

        double result = 0;

        if (hour >= DateTime.Parse("14:00") && hour <= DateTime.Parse("18:59"))
        {
            result = 2 * totalFlats * 100.53 + 2 * totalFlats * 125.90;
        }

        else if (hour >= DateTime.Parse("17:00") && hour <= DateTime.Parse("23:59"))
        {
            result = 7 * totalFlats * 100.53 + 6 * totalFlats * 125.90;
        }

        else if (hour >= DateTime.Parse("00:00") && hour <= DateTime.Parse("08:59"))
        {
            result = 1 * totalFlats * 100.53 + 8 * totalFlats * 125.90;
        }

        Console.WriteLine("{0} Watts", (int)result);
    }
}
