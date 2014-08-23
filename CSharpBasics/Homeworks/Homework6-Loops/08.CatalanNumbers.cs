using System;
using System.Numerics;

/* Write a program to calculate the nth Catalan number by given n (1 < n < 100). */

class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Please enter a number between 2 and 99.\nn = ");
        byte n;

        while (!byte.TryParse(Console.ReadLine(), out n) || n < 2 || n > 99)
        {
            Console.Write("\nInvalid number - n should be and integer between 2 and 99. Please re-enter.\nn = ");
        }
        
        BigInteger numerator = 1;
        BigInteger denominator = 1;

        for (int k = 2; k <= n; k++)
        {
            numerator *= n + k;
            denominator *= k;
        }  
   

        BigInteger catalanNumber = numerator / denominator;

        Console.WriteLine("\nThe n-th Catalan number is: {0}\n", catalanNumber);
    }
}
