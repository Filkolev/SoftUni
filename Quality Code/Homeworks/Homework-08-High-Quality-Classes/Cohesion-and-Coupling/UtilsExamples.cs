namespace CohesionAndCoupling
{
    using System;
    using Files;
    using Geometry.Geometry2D;
    using Geometry.Geometry3D;

    public class UtilsExamples
    {
        public static void Main()
        {
            // Console.WriteLine(FileUtils.GetFileExtension("example")); // Exception is thrown when extension is not entered
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalcDistance2D(1, -2, 3, 4));

            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Figure3D figure = new Figure3D(3, 4, 5);

            Console.WriteLine(
                "Volume = {0:f2}",
                Geometry3DUtils.CalcVolume(figure));

            Console.WriteLine(
                "Diagonal XYZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalXYZ(figure));

            Console.WriteLine(
                "Diagonal XY = {0:f2}",
                Geometry3DUtils.CalcDiagonalXY(figure));

            Console.WriteLine(
                "Diagonal XZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalXZ(figure));

            Console.WriteLine(
                "Diagonal YZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalYZ(figure));
        }
    }
}
