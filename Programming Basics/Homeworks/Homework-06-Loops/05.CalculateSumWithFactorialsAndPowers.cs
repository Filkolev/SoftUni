using System;
using System.Numerics;

/* Write a program that, for a given two integer numbers n and x, 
 calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n. Use only one loop. 
 Print the result with 5 digits after the decimal point. */

class CalculateSumWithFactorialsAndPowers
{
    static void Main()
    {        
        Console.Write("n = ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n)) // Auxiliary loop
        {
            Console.Write("The number you entered isn't valid, please re-enter.\nn =  ");
        }

        Console.Write("x = ");
        int x;
        while (!int.TryParse(Console.ReadLine(), out x)) // Auxiliary loop
        {
            Console.Write("\nThe number you entered isn't valid, please re-enter.\nx =  ");
        }

        BigInteger factorial = 1;
        BigInteger sum = 1;

        for (int i = 1; i <= n; i++) // Main loop
        {
            factorial *= i;
            sum += factorial / (BigInteger)Math.Pow(x, i);
        }

        Console.WriteLine("\nResult:");
        Console.WriteLine("{0:F5}\n", sum);
    }
}
