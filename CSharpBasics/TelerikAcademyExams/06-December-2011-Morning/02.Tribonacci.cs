using System;
using System.Numerics;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/12

class Tribonacci
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(GetTriboN(t1, t2, t3, n));        
    }

    static BigInteger GetTriboN(BigInteger t1, BigInteger t2, BigInteger t3, int n)
    {
        if (n == 1)
        {
            return t1;
        }
        else if (n == 2)
        {
            return t2;
        }
        else if (n == 3)
        {
            return t3;
        }
        else
        {
            BigInteger tn = 0;

            for (int i = 4; i <= n; i++)
            {
                tn = t1 + t2 + t3;
                t1 = t2;
                t2 = t3;
                t3 = tn;
            }

            return tn;
        }
    }
}
