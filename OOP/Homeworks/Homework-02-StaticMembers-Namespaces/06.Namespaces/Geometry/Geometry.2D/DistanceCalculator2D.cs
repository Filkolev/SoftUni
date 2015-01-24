
namespace Geometry.Geometry2D
{
    using System;

    static class DistanceCalculator2D
    {
        public static double CalculateDistance2D(Point2D a, Point2D b)
        {
            double deltaX = a.XCoordinate - b.XCoordinate;
            double deltaY = a.YCoordinate - b.YCoordinate;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}
