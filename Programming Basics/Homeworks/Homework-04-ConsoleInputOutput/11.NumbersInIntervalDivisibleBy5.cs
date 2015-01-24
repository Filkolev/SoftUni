using System;

/* Write a program that reads two positive integer numbers and prints how many numbers p exist 
 between them such that the reminder of the division by 5 is 0. */

class NumbersInIntervalDivisibleBy5
{
    static void Main()
    {
        Console.Write("Please enter the first number of the interval: ");
        uint lowerBound = uint.Parse(Console.ReadLine());
        Console.Write("Please enter the last number of the interval: ");
        uint upperBound = uint.Parse(Console.ReadLine());

        int countOfDivisible = 0;

        for (uint i = lowerBound; i <= upperBound; i++)
        {
            if (i % 5 == 0)
            {
                countOfDivisible++ ;
            }
        }

        Console.WriteLine(
            "\nThere are {0} numbers between {1} and {2} which are divisible by 5 with remainder 0.\n", 
            countOfDivisible, lowerBound, upperBound);

    }
}
