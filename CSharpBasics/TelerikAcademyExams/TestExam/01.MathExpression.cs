using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/6

class MathExpression
{
    static void Main()
    {
        double N = double.Parse(Console.ReadLine());
        double M = double.Parse(Console.ReadLine());
        double P = double.Parse(Console.ReadLine());

        const int numeratorNumber = 1337;
        const double denominatorNumber = 128.523123123;

        double numerator = 0.0;
        double denominator = 0.0;        

        double result = 0.0;

        numerator += N * N;
        numerator += 1 / (M * P);
        numerator += numeratorNumber;

        denominator += N;
        denominator -= denominatorNumber * P;

        result = numerator / denominator;

        result += Math.Sin((int)M % 180);        

        Console.WriteLine("{0:F6}", result);
    }
}
