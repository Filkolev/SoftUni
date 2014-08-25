using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/43

class Cinema
{
    static void Main()
    {
        string typeOFProjection = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        double revenues = rows * columns;

        switch (typeOFProjection)
        {
            case "Premiere": revenues *= 12;
                break;
            case "Normal": revenues *= 7.5;
                break;
            case "Discount": revenues *= 5;
                break;           
        }

        Console.WriteLine("{0:F2} leva", revenues);
    }
}
