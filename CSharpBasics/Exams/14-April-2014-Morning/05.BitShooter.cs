using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/82

class BitShooter
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        string[] firstShot = Console.ReadLine().Split();
        string[] secondShot = Console.ReadLine().Split();
        string[] thirdShot = Console.ReadLine().Split();

        int firstCenter = int.Parse(firstShot[0]);
        int firstSize = int.Parse(firstShot[1]);

        int secondCenter = int.Parse(secondShot[0]);
        int secondSize = int.Parse(secondShot[1]);

        int thirdCenter = int.Parse(thirdShot[0]);
        int thirdSize = int.Parse(thirdShot[1]);

        int rightCount = 0;
        int leftCount = 0;

        TakeTheShot(ref number, firstCenter, firstSize);
        TakeTheShot(ref number, secondCenter, secondSize);
        TakeTheShot(ref number, thirdCenter, thirdSize);

        for (int i = 0; i < 32; i++)
        {
            if ((number & 1) == 1)
            {
                rightCount++;                
            }

            number = number >> 1;
        }

        while (number > 0)
        {
            if ((number & 1) == 1)
            {
                leftCount++;                
            }

            number = number >> 1;
        }

        Console.WriteLine("left: {0}", leftCount);
        Console.WriteLine("right: {0}", rightCount);

    }

    private static void TakeTheShot(ref ulong number, int center, int size)
    {
        int rightmostBit = Math.Max(center - size / 2, 0);
        int leftmostBit = Math.Min(center + size / 2, 63);

        for (int index = rightmostBit; index <= leftmostBit; index++)
        {
            ulong one = 1u;
            ulong mask = ~(one << index);
            number = number & mask;
        }       
    }
}
