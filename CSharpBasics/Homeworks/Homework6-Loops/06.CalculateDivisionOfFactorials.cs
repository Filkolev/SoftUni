using System;
using System.Numerics;

/* Write a program that calculates n! / k! for given n and k (1 < k < n < 100). 
 Use only one loop. */

class CalculateDivisionOfFactorials
{
    static void Main()
    {
        Console.Write("n = ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.Write("The number you entered isn't valid, please re-enter.\nn =  ");
        }

        Console.Write("k = ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("The number you entered isn't valid, please re-enter.\nk =  ");
        }

        BigInteger result = 1;

        for (int i = 0; i < n - k; i++)
        {
            result *= (k + 1 + i);
        }

        Console.WriteLine("\nn!/k! = {0}\n", result);
    }
}
