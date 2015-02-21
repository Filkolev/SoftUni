namespace Geometry
{
    using System;

    public class GeometryMain
    {
        public static void Main()
        {
            Console.WriteLine(GeometryMethods.CalcTriangleArea(3, 4, 5));

            double distance = GeometryMethods.CalcDistance(3, -1, 3, 2.5);
            bool isHorizontalLine = GeometryMethods.IsHorizontalLine(3, -1, 3, 2.5);
            bool isVerticalLine = GeometryMethods.IsVerticalLine(3, -1, 3, 2.5);

            Console.WriteLine(distance);
            Console.WriteLine("Horizontal? " + isHorizontalLine);
            Console.WriteLine("Vertical? " + isVerticalLine);
        }
    }
}
