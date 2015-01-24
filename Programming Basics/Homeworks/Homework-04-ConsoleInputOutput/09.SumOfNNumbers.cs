using System;

/* Write a program that enters a number n and after that enters more n numbers 
and calculates and prints their sum. Note that you may need to use a for-loop. */

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int n = int.Parse(Console.ReadLine());

        double sum = 0.0;

        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nThe sum of the {0} numbers is {1}.\n", n, sum);
    }
}
