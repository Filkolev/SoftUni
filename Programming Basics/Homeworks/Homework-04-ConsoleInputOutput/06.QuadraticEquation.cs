using System;

// Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("A quadratic equation has the form: ax^2 + bx + c = 0, where a, b and c are real coefficients. Enter the coefficients below to find out what are the real roots of the equation (if any).");
            
        Console.Write("\na = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        double D = b * b - 4 * a * c;
        if (D < 0)
        {
            Console.WriteLine("\nThe equation {0}x^2 + {1}x + {2} has no real roots.\n", a, b, c);
        }

        else if (D == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("\nThe equation {0}x^2 + {1}x + {2} has one real root x1 = x2 = {3}.\n", a, b, c, x);
        }

        else
        {
            double x1 = (-b - Math.Sqrt(D)) / (2 * a);
            double x2 = (-b + Math.Sqrt(D)) / (2 * a);
            Console.WriteLine("\nThe equation {0}x^2 + {1}x + {2} has two real roots: x1 = {3} and x2 = {4}.\n", a, b, c, x1, x2);
        }

    }
}
