using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            int num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Number cannot be negative.");
            }

            double squareRoot = Math.Sqrt(num);
            Console.WriteLine(squareRoot);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}

