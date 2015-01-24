using System;

/* Write a program that shows the sign (+, - or 0) of the product of three real 
 * numbers, without calculating it. Use a sequence of if operators. */

class MultiplicationSign
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers a, b and c.");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        int numberOfMinusSigns = 0;

        if (a < 0)
        {
            numberOfMinusSigns++;
        }

        if (b < 0)
        {
            numberOfMinusSigns++;
        }

        if (c < 0)
        {
            numberOfMinusSigns++;
        }

        Console.Write("\nThe sign of the multiplication is: ");

        if (a == 0 || b == 0 || c == 0)
	    {
		 Console.WriteLine(0);
	    }

        else
	    {
            string signOfProduct = (numberOfMinusSigns % 2 == 0 ? "+.\n" : "-.\n");
            Console.WriteLine(signOfProduct);
	    }   
    }
}
