
namespace Geometry.Geometry2D
{
    using System;

    class Rectangle : Figure2D
    {
        /// <summary>
        /// The point representing the upper-left corner of the rectangle.
        /// </summary>
        private Point2D location;
        private double width;
        private double height;

        public Rectangle(Point2D location, double width = 0, double height = 0)
        {
            this.Location = location;
            this.Width = width;
            this.Height = height;
        }

        public Point2D Location { get; set; }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("width", "Width cannot be negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("height", "Height cannot be negative.");
                }

                this.height = value;
            }
        }

        public double Area
        {
            get { return this.Width * this.Height; }
        }
    }
}
