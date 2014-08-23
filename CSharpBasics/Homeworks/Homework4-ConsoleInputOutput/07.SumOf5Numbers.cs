using System;

// Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum. 

class SumOf5Numbers
{
    static void Main()
    {
        double sum = 0.0;

        Console.Write("Enter five numbers on a single line separated by space to find their sum: ");
            
        string[] numbers = Console.ReadLine().Split();

        for (int i = 0; i < 5; i++)
        {
            sum += double.Parse(numbers[i]);
        }

        Console.WriteLine("\nThe sum is {0}.\n", sum);
       
    }
}
