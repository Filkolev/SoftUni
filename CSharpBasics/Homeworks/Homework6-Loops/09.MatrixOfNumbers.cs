using System;

/* Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) 
 and prints a matrix like in the examples below. Use two nested loops.  */

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Please enter an integer between 1 and 20.\nn = ");
        byte n;

        while (!byte.TryParse(Console.ReadLine(), out n) || n < 1 || n > 20)
        {
            Console.WriteLine("Invalid number, please re-enter.\nn = ");
        }

        Console.WriteLine("\nResult: \n");

        for (byte i = 1; i <= n; i++)
        {
            for (byte j = 0; j < n; j++)
            {
                Console.Write("{0,2} ", i + j);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
