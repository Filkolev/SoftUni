using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/442

class Fire
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());

        int outerDots = width / 2 - 1;
        int innerDots = 0;

        for (int i = 0; i < width / 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots--;
            innerDots += 2;
        }

        outerDots++;
        innerDots -= 2;

        for (int i = 0; i < width / 4; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', outerDots), new string('.', innerDots));
            outerDots++;
            innerDots -= 2;
        }

        Console.WriteLine(new string('-', width));

        outerDots = 0;
        int slashCount = width / 2;

        for (int i = 0; i < width / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}{0}", new string('.', outerDots), new string('\\', slashCount), new string('/', slashCount));
            outerDots++;
            slashCount--;
        }
    }
}
