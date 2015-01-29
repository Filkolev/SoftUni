
namespace Geometry.Geometry2D
{
    using System;

    class Circle : Figure2D
    {
        private double radius;

        public Circle(Point2D center, double radius = 0)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Point2D Center { get; set; }

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
    }
}
