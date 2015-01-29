
namespace Geometry.Geometry2D
{
    using System;

    class Square : Figure2D
    {
        /// <summary>
        /// The point representing the upper-left corner of the square.
        /// </summary>
        private Point2D location;
        private double sideLength;
        
        public Square(Point2D location, double sideLength = 0)
        {
            this.Location = location;
            this.SideLength = sideLength;
        }

        public Point2D Location { get; set; }

        public double SideLength
        {
            get { return this.sideLength; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sideLength", "Height cannot be negative.");
                }

                this.sideLength = value;
            }
        }

        public double Area
        {
            get { return this.SideLength * this.SideLength; }
        }
    }
}
