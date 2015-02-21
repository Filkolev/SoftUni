namespace _02.FractionCalculator
{
    using System;
    using System.Numerics;

    struct Fraction
    {
        private long numerator;
        private long denominator;

        /// <summary>
        /// Creates a Fraction object in normal form where the numerator and denominator are polynomials whose greatest common divisor is 1 and the denominator is positive.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        public Fraction(long numerator, long denominator)
            : this()
        {
            long greatestCommonDivisor = GetGreatestCommonDivisor(numerator, denominator);
            if (greatestCommonDivisor > 1)
            {
                numerator /= greatestCommonDivisor;
                denominator /= greatestCommonDivisor;
            }

            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator of a rational number cannot be zero.");
                }

                if (value < 0)
                {
                    value *= -1;
                    this.Numerator *= -1;
                }

                this.denominator = value;
            }
        }

        public double Value
        {
            get
            {
                double value = (double)this.Numerator / this.Denominator;
                return value;
            }
        }

        public static Fraction operator +(Fraction fractionA, Fraction fractionB)
        {
            BigInteger resultNumerator = ((BigInteger)fractionA.Numerator * fractionB.Denominator) +
                                         ((BigInteger)fractionA.Denominator * fractionB.Numerator);

            BigInteger resultDenominator = (BigInteger)fractionA.Denominator * fractionB.Denominator;

            BigInteger gcd = GetGreatestCommonDivisor(resultNumerator, resultDenominator);

            if (gcd > 1)
            {
                resultNumerator /= gcd;
                resultDenominator /= gcd;
            }

            if (resultNumerator < long.MinValue || long.MaxValue < resultNumerator)
            {
                throw new ArithmeticException("Numerator of resulting fraction is either too large or too small.");
            }

            if (resultDenominator > long.MaxValue)
            {
                throw new ArithmeticException("Denominator of resulting fraction is too large.");
            }

            return new Fraction((long)resultNumerator, (long)resultDenominator);
        }

        public static Fraction operator -(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = fractionA + new Fraction(fractionB.Numerator * -1, fractionB.Denominator);
            return result;
        }

        public static Fraction operator *(Fraction fractionA, Fraction fractionB)
        {
            BigInteger resultNumerator = (BigInteger)fractionA.Numerator * fractionB.Numerator;
            BigInteger resultDenominator = (BigInteger)fractionA.Denominator * fractionB.Denominator;

            BigInteger gcd = GetGreatestCommonDivisor(resultNumerator, resultDenominator);

            if (gcd > 1)
            {
                resultNumerator /= gcd;
                resultDenominator /= gcd;
            }

            if (resultNumerator < long.MinValue || long.MaxValue < resultNumerator)
            {
                throw new ArithmeticException("Numerator of resulting fraction is either too large or too small.");
            }

            if (resultDenominator > long.MaxValue)
            {
                throw new ArithmeticException("Denominator of resulting fraction is too large.");
            }

            return new Fraction((long)resultNumerator, (long)resultDenominator);
        }

        public static Fraction operator /(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = fractionA * new Fraction(fractionB.Denominator, fractionB.Numerator);
            return result;
        }

        public override string ToString()
        {
            string result = this.Value.ToString();
            return result;
        }

        private static long GetGreatestCommonDivisor(BigInteger numerator, BigInteger denominator)
        {
            if (numerator < 0)
            {
                numerator *= -1;
            }

            if (denominator < 0)
            {
                denominator *= -1;
            }

            while (denominator != 0)
            {
                BigInteger tempDenominator = denominator;
                denominator = numerator % denominator;
                numerator = tempDenominator;
            }

            return (long)numerator;
        }
    }
}
