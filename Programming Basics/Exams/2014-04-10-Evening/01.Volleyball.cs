using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/22

class Volleyball
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine()); 
        int hometownWeekends = int.Parse(Console.ReadLine()); 

        int normalWeekends = 48 - hometownWeekends;
        double result = 0.0;

        result += hometownWeekends;
        result += normalWeekends * 3.0 / 4;
        result += holidays * 2.0 / 3;
        
        if (isLeap == "leap")
	    {
        result *= 1.15;
	    }

        Console.WriteLine(Math.Floor(result));         
    }
}
