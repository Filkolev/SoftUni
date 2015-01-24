using System;

/* Write a program that enters from the console a positive integer n 
 and prints all the numbers from 1 to n, on a single line, separated by a space. */

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Please enter a positive integer: ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
        {
            Console.Write("\nThe number you entered isn't valid, please re-enter: ");
        }

        Console.WriteLine("\nHere are all integer numbers between 1 and {0}:", n);

        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ", i);             
        }        
    }
}
