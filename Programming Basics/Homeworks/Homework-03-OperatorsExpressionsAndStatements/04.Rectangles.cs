using System;

// Write an expression that calculates rectangle’s perimeter and area by given width and height. 

class Rectangles
{
    static void Main()
    {
        Console.WriteLine("Enter the width and height of a rectangle to find it's perimeter and area.");
        Console.Write("\nPlease enter the rectangle's width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Please enter the rectangle's height: ");
        double height = double.Parse(Console.ReadLine());

        double perimeter = 2 * (width + height);
        double area = width * height;

        Console.WriteLine("\n"+new string('*',40));
        Console.WriteLine("The perimeter of the rectangle is: "+perimeter);
        Console.WriteLine("The area of the rectangle is: "+area);
        Console.WriteLine(new string('*', 40));
        Console.WriteLine();
    }
}
