using System;

/* Write a program that calculates the greatest common divisor (GCD) of 
 given two integers a and b. Use the Euclidean algorithm (find it in Internet). */

class CalculateGCD
{
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());        
        
        int biggerNumber = Math.Max(Math.Abs(a), Math.Abs(b));

        int smallerNumber = Math.Min(Math.Abs(a), Math.Abs(b));

        int remainder = biggerNumber - smallerNumber;

        while (remainder > 0)
        {
            while (remainder > smallerNumber)
            {
                remainder -= smallerNumber;
            }

            biggerNumber = smallerNumber;
            smallerNumber = remainder;
            remainder = biggerNumber - smallerNumber;
        }

        Console.WriteLine("\nThe greatest common divisor (GCD) of {0} and {1} is: {2}.\n", a, b, smallerNumber);       
    }
}
