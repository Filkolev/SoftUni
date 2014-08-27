using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/504

class PieceOfCake
{
    static void Main()
    {
        long A = int.Parse(Console.ReadLine());
        long B = int.Parse(Console.ReadLine());
        long C = int.Parse(Console.ReadLine());
        long D = int.Parse(Console.ReadLine());

        long numerator = A * D + B * C;
        long denominator = B * D;
        decimal result = ((decimal)A / (decimal)B) + ((decimal)C / (decimal)D);

        if (numerator >= denominator)
        {
            Console.WriteLine((long)(result));
        }

        else
        {
            Console.WriteLine("{0:F22}", result);
        }

        Console.WriteLine("{0}/{1}", numerator, denominator);
    }
}
