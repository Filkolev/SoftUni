using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/84

class InsideTheBuilding
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());

        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        int x3 = int.Parse(Console.ReadLine());
        int y3 = int.Parse(Console.ReadLine());

        int x4 = int.Parse(Console.ReadLine());
        int y4 = int.Parse(Console.ReadLine());

        int x5 = int.Parse(Console.ReadLine());
        int y5 = int.Parse(Console.ReadLine());

        CheckPointPosition(size, x1, y1);
        CheckPointPosition(size, x2, y2);
        CheckPointPosition(size, x3, y3);
        CheckPointPosition(size, x4, y4);
        CheckPointPosition(size, x5, y5);    
    }

    private static void CheckPointPosition(int size, int x, int y)
    {
        if (isInside(x, y, size))
        {
            Console.WriteLine("inside");
        }

        else
        {
            Console.WriteLine("outside");
        }
    }

    public static bool isInside(int x, int y, int h)
    {
        if (x >= 0 && x <= 3 * h && y >= 0 && y <= h )
        {
            return true;
        }

        else if (x >= h && x <= 2 * h && y >= 0 && y <= 4 * h)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
