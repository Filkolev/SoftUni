using System;

// Write a program that finds the biggest of three numbers.

class BiggestOf3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers a, b and c to find the biggest.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        double biggestNumber = Math.Max(a, b);
        biggestNumber = Math.Max(biggestNumber, c);

        Console.WriteLine("\nThe biggest of the three numbers is {0}.\n", biggestNumber);
    }
}
