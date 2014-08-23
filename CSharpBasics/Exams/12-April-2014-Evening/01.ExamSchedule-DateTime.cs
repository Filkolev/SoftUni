using System;

class ExamSchedule
{
    static void Main()
    {
        int hour = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        string timeOfDay = Console.ReadLine();
        int hourEnd = int.Parse(Console.ReadLine());
        int minutesEnd = int.Parse(Console.ReadLine());

        if (timeOfDay == "PM")
        {
            hour += 12;
        }

        DateTime start = new DateTime(2014, 1, 1, hour, minutes, 0);

        DateTime end = start.AddHours(hourEnd).AddMinutes(minutesEnd);

        Console.WriteLine("{0:hh:mm:tt}", end);
    }
}
