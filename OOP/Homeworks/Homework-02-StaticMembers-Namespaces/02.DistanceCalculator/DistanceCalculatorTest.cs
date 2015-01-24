using System;
using Point;

class DistanceCalculatorTest
{
    static void Main()
    {
        Point3D a = new Point3D(-7, -4, 3);
        Point3D b = new Point3D(17, 6, 2.5);

        Console.WriteLine(DistanceCalculator.CalculateDistance(a, b));
    }
}

