namespace Point
{
    using System;

    public class Point3D
    {
        private double xCoordinate;
        private double yCoordinate;
        private double zCoordinate;
        private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public double ZCoordinate { get; set; }

        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        public Point3D(double xCoordinate = 0, double yCoordinate = 0, double zCoordinate = 0)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.ZCoordinate = zCoordinate;
        }

        public override string ToString()
        {
            return String.Format(
                "Point ({0}, {1}, {2})",
                this.XCoordinate, this.YCoordinate, this.ZCoordinate);
        }
    }
}
