using System;
using System.Collections.Generic;

/* Write a method that calculates all prime numbers in given range and returns them as list of integers. 
Write a method to print a list of integers. Write a program that enters two integer numbers (each at a separate line) 
and prints all primes in their range, separated by a comma. */


class PrimesInGivenRange
{
    static void Main()
    {
        int startNum;
        int endNum;

        Console.Write("Enter the first number of the interval: ");
        while (!int.TryParse(Console.ReadLine(), out startNum))
        {
            Console.WriteLine("Invalid number, please re-enter");
        }

        Console.Write("Enter the last number of the interval: ");
        while (!int.TryParse(Console.ReadLine(), out endNum))
        {
            Console.WriteLine("Invalid number, please re-enter");
        }

        // There are no primes less than 2
        if (startNum < 2)
        {
            startNum = 2;
        }

        // If the second number entered is smaller than 2 or the first number, the list will be empty
        if (endNum < startNum)
        {
            Console.WriteLine("\n(empty list)\n");
            return;
        }

        List<int> primes = new List<int>();
        FindPrimesInRange(startNum, endNum, primes);

        if (primes.Count == 0)
        {
            Console.WriteLine("\n(empty list)\n");
        }

        else
        {
            Console.Write("\nHere are all primes between {0} and {1}:\n", startNum, endNum);
        }

        PrintList(primes);
    }


    static void FindPrimesInRange(int startNum, int endNum, List<int> primes)
    {

        for (int number = startNum; number <= endNum; number++)
        {
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime)
            {
                primes.Add(number);
            }
        }
    }

    static void PrintList(List<int> primes)
    {
        for (int i = 0; i < primes.Count - 1; i++)
        {
            Console.Write("{0}, ", primes[i]);
        }

        // skip comma after last element
        Console.Write(primes[primes.Count - 1]);
        Console.WriteLine();
        Console.WriteLine();
    }
}
