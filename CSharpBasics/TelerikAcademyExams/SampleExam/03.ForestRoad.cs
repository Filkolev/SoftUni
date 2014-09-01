using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/3

class ForestRoad
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int leftDots = 0;
        int rightDots = size - 1;

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("{0}*{1}", new string('.', leftDots), new string('.', rightDots));

            leftDots++;
            rightDots--;
        }

        leftDots -= 2;
        rightDots += 2;

        for (int i = 0; i < size - 1; i++)
        {
            Console.WriteLine("{0}*{1}", new string('.', leftDots), new string('.', rightDots));

            leftDots--;
            rightDots++;
        }
    }
}
