using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/8

class Trapezoid
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int leftDots = size;
        int innerSymbols = size - 2;

        for (int i = 0; i < size + 1; i++)
        {
            if (i == 0 || i == size)
            {
                Console.WriteLine("{0}*{1}*", new string('.', leftDots), new string('*', innerSymbols));
            }
            else
            {
                Console.WriteLine("{0}*{1}*", new string('.', leftDots), new string('.', innerSymbols));
            }

            leftDots--;
            innerSymbols++;
        }
    }
}
