namespace Geometry.Geometry2D
{
    class Point2D
    {
        private double xCoordinate;
        private double yCoordinate;

        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public Point2D(double xCoordinate = 0, double yCoordinate = 0)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }
    }
}
