using System;

/* Write a program that enters 3 integers n, min and max (min ≤ max) 
 and prints n random numbers in the range [min...max].  */

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Write("n = ");        
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
        {
            Console.Write("The number you entered isn't valid, please enter a positive integer.\nn =  ");
        }
                
        Console.Write("min = ");
        int min;
        while (!int.TryParse(Console.ReadLine(), out min))
        {
            Console.Write("The number you entered isn't valid, please re-enter.\nmin =  =  ");
        }

        Console.Write("max = ");
        int max;
        while (!int.TryParse(Console.ReadLine(), out max) || max < min)
        {
            Console.Write("The number you entered isn't valid - max should be an integer greater than or equal to min).\nmax =  ");
        }

        Console.WriteLine("\nHere are {0} random numbers between {1} and {2}:", n, min, max);

        Random randomInteger = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", randomInteger.Next(min, max + 1));
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}
