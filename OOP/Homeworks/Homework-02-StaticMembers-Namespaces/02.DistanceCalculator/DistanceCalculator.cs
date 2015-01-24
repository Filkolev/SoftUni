using System;
using Point;

public static class DistanceCalculator
{
    public static double CalculateDistance(Point3D pointA, Point3D pointB)
    {
        double deltaX = pointA.XCoordinate - pointB.XCoordinate;
        double deltaY = pointA.YCoordinate - pointB.YCoordinate;
        double deltaZ = pointA.ZCoordinate - pointB.ZCoordinate;

        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

        return distance;
    }
}

