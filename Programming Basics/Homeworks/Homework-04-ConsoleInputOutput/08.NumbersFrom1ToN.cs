using System;

/* Write a program that reads an integer number n from the console and prints 
all the numbers in the interval [1..n], each on a single line. Note that you 
may need to use a for-loop. */

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();

        if (n >= 1)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }

        else
        {
            for (int i = 1; i >= n; i--)
            {
                Console.WriteLine(i);
            }
        }
            

        Console.WriteLine();            
    }
}
