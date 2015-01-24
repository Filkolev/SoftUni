using System;
using System.Numerics;

/* Write a program that calculates n! / k! for given n and k (1 < k < n < 100). 
 Use only one loop. */

class CalculateDivisionOfFactorials
{
    static void Main()
    {
        Console.Write("k = ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k < 2 || k > 99)
        {
            Console.Write("The number you entered isn't valid - k should be an integer between 2 and 99, please re-enter.\nk =  ");
        }

        Console.Write("n = ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= k || n > 99)
        {
            Console.Write("The number you entered isn't valid - n should be an integer between {0} and 99, please re-enter.\nn =  ", k + 1);
        }

        BigInteger result = 1;

        for (int i = 0; i < n - k; i++)
        {
            result *= (k + 1 + i);
        }

        Console.WriteLine("\nn!/k! = {0}\n", result);
    }
}
