namespace CohesionAndCoupling.Geometry.Geometry3D
{
    using System;
    using Geometry2D;

    public static class Geometry3DUtils
    {
        public static double CalcDistance3D(double x1, double y1, double x2, double y2, double z1, double z2)
        {
            double deltaX = x1 - x2;
            double deltaY = y1 - y2;
            double deltaZ = z1 - z2;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));

            return distance;
        }

        public static double CalcVolume(Figure3D figure)
        {
            double volume = figure.Width * figure.Height * figure.Depth;

            return volume;
        }

        public static double CalcDiagonalXYZ(Figure3D figure)
        {
            double distance = CalcDistance3D(0, figure.Width, 0, figure.Height, 0, figure.Depth);

            return distance;
        }

        public static double CalcDiagonalXY(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, figure.Width, 0, figure.Height);

            return distance;
        }

        public static double CalcDiagonalXZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, figure.Width, 0, figure.Depth);

            return distance;
        }

        public static double CalcDiagonalYZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, figure.Height, 0, figure.Depth);

            return distance;
        }
    }
}
