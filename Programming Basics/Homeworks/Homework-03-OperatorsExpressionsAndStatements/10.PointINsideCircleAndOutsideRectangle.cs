using System;

// Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

    class PointInsideCircleOutsideRectangle
    {
        static void Main()
        {
            Console.WriteLine("Enter the coordinates of a point to check if it's inside the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).\n");
            
            Console.Write("x-coordinate: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y-coordinate: ");
            double y = double.Parse(Console.ReadLine());
            
            double distanceFromCenterOfCircle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
            
            bool isInCircle = (distanceFromCenterOfCircle <= 1.5); 

            bool isOutsideRectangle;

            if (-1 <= x && x <= 5 && -1 <= y && y <= 1 )
            {
                isOutsideRectangle = false;
            }
            else
            {
                isOutsideRectangle = true;
            }

            Console.WriteLine();

            // Output
            if (isInCircle && isOutsideRectangle)
            {
                Console.WriteLine("True: the point with coordinates ({0}, {1}) is inside the circle and outside the rectangle.", x, y);
            }

            else if (isInCircle && !isOutsideRectangle)
            {
                Console.WriteLine("False: the point with coordinates ({0}, {1}) is inside the circle but also inside the rectangle.", x, y);
            }

            else if (!isInCircle && isOutsideRectangle)
            {
                Console.WriteLine("False: the point with coordinates ({0}, {1}) is outside the rectangle but also outside the circle.", x, y);
            }

            else
            {
                Console.WriteLine("False: the point with coordinates ({0}, {1}) is outside the circle and inside the rectangle.", x, y);
            }

            Console.WriteLine();
        }
    }
