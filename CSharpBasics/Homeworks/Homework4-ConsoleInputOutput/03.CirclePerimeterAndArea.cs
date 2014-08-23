using System;

// Write a program that reads the radius r of a circle and prints its perimeter and area 
// formatted with 2 digits after the decimal point.

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Please enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = radius * 2 * Math.PI;
        double area = radius * radius * Math.PI;

        Console.WriteLine(
            "\nThe perimeter of the circle is {0:F2}.\nThe area of the circle is {1:F2}.\n", 
            perimeter,area);

    }
}
