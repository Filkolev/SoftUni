using System;

/* Write a program that enters 3 real numbers and prints them sorted in 
 descending order. Use nested if statements. Don’t use arrays and the built-in 
 sorting functionality. */

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers a, b and c to be sorted in descending order.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        Console.WriteLine("\nResult:");

        if (a >= b && a >= c)
        {
            if (b >= c)
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", a, c, b);
            }
        }

        else if (b >= a && b >= c)
        {
            if (a >= c)
            {
                Console.WriteLine("{0} {1} {2}", b, a, c);
            }

            else
            {
                Console.WriteLine("{0} {1} {2}", b, c, a);
            }
        }

        else
        {
            if (a >= b)
            {
               Console.WriteLine("{0} {1} {2}", c, a, b); 
            }

            else
            {
                Console.WriteLine("{0} {1} {2}", c, b, a);
            }
        }

        Console.WriteLine();
    }
}
