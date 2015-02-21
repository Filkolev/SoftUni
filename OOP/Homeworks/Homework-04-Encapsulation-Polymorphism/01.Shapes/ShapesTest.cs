namespace _01.Shapes
{
    using System;
    using Contracts;
    using Shapes;

    class ShapesTest
    {
        static void Main()
        {
            IShape[] shapes =
            {
                new Circle(2.5),
                new Rectangle(11, 1.2), 
                new Triangle(6, 1.1, 7), 
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    "This is a {0} with area: {1:f2} and perimeter {2:f2}",
                    shape.GetType().Name,
                    shape.CalculateArea(),
                    shape.CalculatePerimeter());
            }

            // Invalid lines -> exceptions
            // new Circle(0);
            // new Rectangle(-1, 1);
            // new Triangle(1, -1);
        }
    }
}
