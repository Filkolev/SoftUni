using System;

// Write a program that finds the biggest of five numbers by using only five if statements.

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers to find the biggest of them.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("d = ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("e = ");
        double e = double.Parse(Console.ReadLine());

        double biggestNumber = a;

        if (b > biggestNumber)
        {
            biggestNumber = b;
        }

        if (c > biggestNumber)
        {
            biggestNumber = c;
        }

        if (d > biggestNumber)
        {
            biggestNumber = d;
        }

        if (e > biggestNumber)
        {
            biggestNumber = e;
        }

        Console.WriteLine("\nThe biggest of the five numbers is {0}.\n", biggestNumber);
    }
}
