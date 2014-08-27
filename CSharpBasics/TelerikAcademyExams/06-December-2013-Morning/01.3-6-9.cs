using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/508

class _3_6_9
{
    static void Main(string[] args)
    {
        long a = long.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());

        long r = 0;

        if (b == 3)
        {
            r = a + c;
        }

        else if (b == 6)
        {
            r = a * c;
        }

        else
        {
            r = a % c;
        }

        Console.WriteLine(r % 3 == 0 ? r / 3 : r % 3);
        Console.WriteLine(r);
    }
}
