using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/272

class UKFlag
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = 0;
        int innerDots = size / 2 - 1;

        for (int i = 0; i < size / 2; i++)
        {
            Console.WriteLine("{0}\\{1}|{1}/{0}", new string('.', outerDots), new string('.', innerDots));

            outerDots++;
            innerDots--;
        }

        Console.WriteLine("{0}*{0}", new string('-', size / 2));

        outerDots = size / 2 - 1;
        innerDots = 0;

        for (int i = 0; i < size / 2; i++)
        {
            Console.WriteLine("{0}/{1}|{1}\\{0}", new string('.', outerDots), new string('.', innerDots));

            outerDots--;
            innerDots++;
        }
    }
}
