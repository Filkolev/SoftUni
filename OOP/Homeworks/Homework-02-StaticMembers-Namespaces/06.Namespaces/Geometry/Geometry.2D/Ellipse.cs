
namespace Geometry.Geometry2D
{
    using System;

    class Ellipse : Figure2D
    {
        private Point2D focus1;
        private Point2D focus2;
        private double minorAxis;
        private double majorAxis;

        public Ellipse(Point2D focus1, Point2D focus2, double minorAxis = 0, double majorAxis = 0)
        {
            this.Focus1 = focus1;
            this.Focus2 = focus2;
            this.MinorAxis = minorAxis;
            this.MajorAxis = majorAxis;
        }

        public Point2D Focus1 { get; set; }
        public Point2D Focus2 { get; set; }

        public double MinorAxis
        {
            get { return this.minorAxis; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("minorAxis", "The length of the minor axis cannot be negative.");
                }

                this.minorAxis = value;
            }
        }

        public double MajorAxis
        {
            get { return this.majorAxis; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("majorAxis", "The length of the major axis cannot be negative.");
                }

                this.majorAxis = value;
            }
        }
    }
}
