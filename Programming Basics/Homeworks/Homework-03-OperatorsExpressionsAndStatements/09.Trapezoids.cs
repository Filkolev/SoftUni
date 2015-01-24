using System;

// Write an expression that calculates trapezoid's area by given sides a and b and height h.

class Trapezoids
{
    static void Main()
    {
        Console.WriteLine("To find the area of a trapezoid, enter the lengths of its bases and it's height below.\n");

        Console.Write("Please enter the length of base a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter the length of base b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter the height h: ");
        double h = double.Parse(Console.ReadLine());

        double area = h * (a + b) / 2;
        Console.WriteLine("\nThe area of the trapezoid is {0}.\n",area);
    }
}
