using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/40

class BitSifting
{
    static void Main()
    {
        ulong initialBit = ulong.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        ulong result = initialBit;
        int countOfOnes = 0;

        if (N != 0)
        {
            for (int i = 0; i < N; i++)
            {
                ulong sift = ulong.Parse(Console.ReadLine());
                result = result & (~sift);
            }
        }

        while (result > 0)
        {
            countOfOnes += (int)(result & 1);
            result >>= 1;
        }

        Console.WriteLine(countOfOnes);
    }
}
