
namespace Geometry.Geometry3D
{
    class Point3D
    {
        private double xCoordinate;
        private double yCoordinate;
        private double zCoordinate;

        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public double ZCoordinate { get; set; }

        public Point3D(double xCoordinate = 0, double yCoordinate = 0, double zCordinate = 0)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.ZCoordinate = zCordinate;
        }
    }
}
