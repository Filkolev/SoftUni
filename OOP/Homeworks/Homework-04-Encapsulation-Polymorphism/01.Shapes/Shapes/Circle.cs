namespace _01.Shapes.Shapes
{
    using System;
    using Contracts;

    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "The radius should be greater than zero.");
                }

                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }
    }
}
