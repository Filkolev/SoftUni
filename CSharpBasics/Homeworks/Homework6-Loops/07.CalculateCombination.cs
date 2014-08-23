using System;
using System.Numerics;

/* In combinatorics, the number of ways to choose k different members out 
 of a group of n different elements (also known as the number of combinations) 
 is calculated by the following formula: n! / (k! * (n-k)!).
For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 
 52 cards. Your task is to write a program that calculates n! / (k! * (n-k)!) for 
 given n and k (1 < k < n < 100). Try to use only two loops. */

class CalculateCombination
{
    static void Main()
    {
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

        for (int i = k + 1; i <= n; i++)
        {
            result *= i;           
        }

        BigInteger divisor = 1;

        for (int i = 1; i <= n - k; i++)
        {
            divisor *= i;
        }

        result /= divisor;

        Console.WriteLine("\nResult: {0}.\n", result);
    }
}
