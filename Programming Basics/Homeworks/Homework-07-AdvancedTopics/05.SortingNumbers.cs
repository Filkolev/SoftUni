using System;
using System.Collections;

// Write a program that reads a number n and a sequence of n integers, sorts them and prints them.

class SortingNumbers
{
    static void Main()
    {
        Console.Write("How many numbers would you like to enter? ");

        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Please enter an integer number greater than 0.");
        }

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            int currentNum;
            Console.Write("Enter number {0}: ", i + 1);
            while (!int.TryParse(Console.ReadLine(), out currentNum))
            {
                Console.WriteLine("Invalid input. Please re-enter.");
                Console.Write("Enter number {0}: ", i + 1);
            }

            numbers[i] = currentNum;
        }

        Array.Sort(numbers);
        Console.WriteLine("\nHere are the numbers sorted from least to greatest:");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(numbers[i]); 
        }

        Console.WriteLine();
    }
}
