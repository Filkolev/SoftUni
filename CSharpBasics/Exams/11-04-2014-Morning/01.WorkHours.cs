using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/32

class WorkHours
{
    static void Main()
    {
        int requiredHours = int.Parse(Console.ReadLine());
        int availableDays = int.Parse(Console.ReadLine()); 
        int productivity = int.Parse(Console.ReadLine()); 

        double available = availableDays * 0.9 * productivity * 12 / 100;

        int result = (int)Math.Floor(available);

        if (result >= requiredHours)
        {
            Console.WriteLine("Yes");
        }

        else
        {
            Console.WriteLine("No");
        }


        Console.WriteLine(result-requiredHours);

    }
}
