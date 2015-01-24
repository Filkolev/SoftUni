using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/12

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());

        int normalWeekends = 52 - hometownWeekends;
        double plays = 0;

        plays += holidays / 2.0;
        plays += (2.0 / 3) * normalWeekends;
        plays += hometownWeekends;

        if (isLeap == "t")
        {
            plays += 3;
        }

        Console.WriteLine((int)plays);
    }
}
