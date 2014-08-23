using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/63

class ExamSchedule
{
    static void Main()
    {
        int startHour = int.Parse(Console.ReadLine());
        int startMinute = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int durationHours = int.Parse(Console.ReadLine());
        int durationMinutes = int.Parse(Console.ReadLine());

        if (partOfDay == "PM")
        {
            startHour += 12;
        }

        if (startHour == 12) // Special case
        {
            startHour -= 12;
        }

        DateTime start = new DateTime(2014, 1, 1, startHour, startMinute, 0); // The date and milliseconds are useless, but necessary

        DateTime end = start.AddHours(durationHours);
        end = end.AddMinutes(durationMinutes);

        Console.WriteLine("{0:hh:mm:tt}", end);
    }
}
