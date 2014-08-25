using System;
using System.Numerics;

class SimpleLoops
{
    static void Main()
    {
        BigInteger T1 = long.Parse(Console.ReadLine());
        BigInteger T2 = long.Parse(Console.ReadLine());
        BigInteger T3 = long.Parse(Console.ReadLine());

        int N = int.Parse(Console.ReadLine());

        BigInteger nextMember = T1 + T2 + T3;

        if (N == 1)
        {
            Console.WriteLine(T1);
        }
        
        else if (N == 2)
        {
            Console.WriteLine(T2);
        }
        
        else if (N == 3)
        {
            Console.WriteLine(T3);
        }

        else
        {
            for (int i = 0; i < N - 4; i++)
            {
                T1 = T2;
                T2 = T3;
                T3 = nextMember;
                nextMember = T1 + T2 + T3;
            }

            Console.WriteLine(nextMember);
        } 
    }
}
