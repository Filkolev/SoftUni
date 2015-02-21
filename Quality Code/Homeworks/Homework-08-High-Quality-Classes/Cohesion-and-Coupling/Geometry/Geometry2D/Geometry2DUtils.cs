namespace CohesionAndCoupling.Geometry.Geometry2D
{
    using System;

    public static class Geometry2DUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double deltaX = x1 - x2;
            double deltaY = y1 - y2;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }
    }
}
