namespace _02.FractionCalculator
{
    using System;

    class FractionCalculatorTest
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);

            // Normalized => numerator and denominator divided by 4 (the GCD of 40 and 4)
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            Fraction test1 = new Fraction(0, -1);
            Console.WriteLine(test1.Numerator);
            Console.WriteLine(test1.Denominator);

            /* Fraction test2 = new Fraction(1, 0); // DivideByZeroException */

            Fraction test3 = new Fraction(5, -3);
            Console.WriteLine(test3.Numerator);
            Console.WriteLine(test3.Denominator);
            Console.WriteLine(test3);

            Fraction test4 = new Fraction(10, 5); // Will be normalized to 2/1
            Console.WriteLine(test4.Numerator);
            Console.WriteLine(test4.Denominator);
            Console.WriteLine(test4);

            Fraction test5 = new Fraction(long.MaxValue, 1);
            Console.WriteLine(test5);
            Fraction test6 = new Fraction(1, 1);
            Console.WriteLine(test6);
            /* Fraction tooLarge = test5 + test6; // ArithmeticException - overflow
            Console.WriteLine(tooLarge); */
        }
    }
}
