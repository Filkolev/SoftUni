using System;
using System.Numerics;

/* Write a program that reads a number n and prints on the console the first n members of the Fibonacci 
 sequence (at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. 
 Note that you may need to learn how to use loops. */

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("How many members of the Fibonacci sequence do you want to print? ");
        int lengthOfSeries = int.Parse(Console.ReadLine());
       
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;

        Console.WriteLine("\nThe first {0} numbers of the Fibonacci sequence are:", lengthOfSeries);

        if (lengthOfSeries == 1)
        {
            Console.WriteLine("{0}", firstMember);
        }
      
        else
        {
            BigInteger nextMember = firstMember + secondMember;
            Console.Write("{0} {1} ", firstMember, secondMember);

            for (int i = 3; i <= lengthOfSeries; i++)
            {
                Console.Write("{0} ", nextMember);
                BigInteger intermediate = nextMember;
                nextMember += secondMember;
                secondMember = intermediate;
            }
            
        }

        Console.WriteLine();
        Console.WriteLine();
        
    }
}
