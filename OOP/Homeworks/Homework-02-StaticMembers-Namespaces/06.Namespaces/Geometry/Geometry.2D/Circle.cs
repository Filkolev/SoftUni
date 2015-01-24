
namespace Geometry.Geometry2D
{
    using System;

    class Circle : Figure2D
    {
        private Point2D center;
        private double radius;

        public Point2D Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        public double Radius
        {
            get { return this.radius; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "Radius cannot be negative.");
                }

                this.radius = value;
            }
        }

        public Circle(Point2D center, double radius = 0)
        {
            this.Center = center;
            this.Radius = radius;
        }
    }
}
