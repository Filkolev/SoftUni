using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/23

class SandGlass
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = 0;
        int innerStars = size;

        for (int i = 0; i < size / 2 + 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', innerStars));

            outerDots++;
            innerStars -= 2;
        }

        outerDots -= 2;
        innerStars += 4;

        for (int i = 0; i < size / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', innerStars));

            outerDots--;
            innerStars += 2;
        }
    }
}
