using System;

// Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2).

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("Please enter the x- and y-coordinates of a point to check if it's inside the circle K({0, 0}, 2).");
        Console.Write("x-coordinate: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y-coordinate: ");
        double y = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(x * x + y * y);
        Console.WriteLine(distance <= 2 ? "\nThe point is inside the circle.\n" : "\nThe point is NOT inside the circle.\n");
    }
}
