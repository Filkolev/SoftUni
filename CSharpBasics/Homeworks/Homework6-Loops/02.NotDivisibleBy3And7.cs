using System;

/* Write a program that enters from the console a positive integer n 
 and prints all the numbers from 1 to n not divisible by 3 and 7, 
 on a single line, separated by a space. */

class NotDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.Write("\nThe number you entered isn't valid, please re-enter: ");
        }

        Console.WriteLine("\nThe numbers between 1 and {0} that are not divisible by 3 and 7 are:", n);

        for (int i = 1; i <= n; i++)
        {
            if (i % 7 != 0 && i % 3 != 0)
            {
                Console.Write("{0} ", i);
            }            
        }        
        
        Console.WriteLine();        
    }
}
