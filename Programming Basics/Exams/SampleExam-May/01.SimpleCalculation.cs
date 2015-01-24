using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/1

class SimpleCalculation
{
    static void Main()
    {
        decimal X = decimal.Parse(Console.ReadLine());
        decimal Y = decimal.Parse(Console.ReadLine());

        if (X == 0 && Y == 0)
        {
            Console.WriteLine(0);
        }

        else if (X > 0 && Y > 0)
        {
            Console.WriteLine(1);
        }

        else if (X < 0 && Y > 0)
        {
            Console.WriteLine(2);
        }

        else if (X < 0 && Y < 0)
        {
            Console.WriteLine(3);
        }

        else if (X > 0 && Y < 0)
        {
            Console.WriteLine(4);
        }

        else if (X == 0 && Y != 0)
        {
            Console.WriteLine(5);
        }

        else if (X != 0 && Y == 0)
        {
            Console.WriteLine(6);
        }
    }
}
