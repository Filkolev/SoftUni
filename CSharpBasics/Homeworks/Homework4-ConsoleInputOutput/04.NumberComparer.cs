using System;

// Write a program that gets two numbers from the console and prints the greater of them. 
// Try to implement this without if statements.

class NumberComparer
{
    static void Main()
    {
        Console.Write("Please enter the first number to be compared: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Please enter the second number to be compared: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("\n{0} is greater than {1}.\n", Math.Max(a, b), Math.Min(a,b));

    }
}
