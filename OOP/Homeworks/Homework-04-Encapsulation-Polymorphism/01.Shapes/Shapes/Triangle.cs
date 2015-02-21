namespace _01.Shapes.Shapes
{
    using System;

    class Triangle : BasicShape
    {
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB)
        {
            this.SideC = sideC;
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("sideC", "All sides of a triangle should be greater than zero.");
                }

                this.sideC = value;
            }
        }

        public override double CalculateArea()
        {
            double halfPerimeter = this.CalculatePerimeter() / 2;

            double areaSquared = halfPerimeter;
            areaSquared *= halfPerimeter - this.Width;
            areaSquared *= halfPerimeter - this.Height;
            areaSquared *= halfPerimeter - this.SideC;

            double area = Math.Sqrt(areaSquared);

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.SideC;
            return perimeter;
        }
    }
}
