namespace Geometry
{
    using System;

    public static class GeometryMethods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides' lengths of a triangle should be positive.");
            }

            if (a + b < c ||
                a + c < b ||
                b + c < a)
            {
                throw new ArgumentOutOfRangeException(
                    "The side lengths provided do not form a valid triangle. Each side should be smaller than the sum of the other two.");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x1 - x2;
            double deltaY = y1 - y2;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }

        public static bool IsHorizontalLine(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = y1 == y2;

            return isHorizontal;
        }

        public static bool IsVerticalLine(double x1, double y1, double x2, double y2)
        {
            bool isVertical = x1 == x2;

            return isVertical;
        }
    }
}
