namespace _01.InterestCalculator
{
    using System;

    class InterestCalculatorTest
    {
        public const int MonthsInYear = 12;

        public static decimal GetSimpleInterest(decimal balance, decimal interestRate, int years)
        {
            decimal interestMultiplier = 1 + (interestRate * years);
            decimal balanceWithInterest = balance * interestMultiplier;

            return decimal.Round(balanceWithInterest, 4);
        }

        private static decimal GetCompoundInterest(decimal balance, decimal interestRate, int years)
        {
            decimal interestMultiplierBase = 1 + (interestRate / MonthsInYear);
            int interestMultiplierPower = years * MonthsInYear;

            decimal interestMultiplier = 1;
            for (int i = 0; i < interestMultiplierPower; i++)
            {
                interestMultiplier *= interestMultiplierBase;
            }

            decimal balanceWithInterest = balance * interestMultiplier;

            return decimal.Round(balanceWithInterest, 4);
        }

        static void Main()
        {
            InterestCalculator compoundInterest = new InterestCalculator(500m, 0.056m, 10, GetCompoundInterest);
            Console.WriteLine(compoundInterest.AccruedInterest);

            InterestCalculator simpleInterest = new InterestCalculator(2500m, 0.072m, 15, GetSimpleInterest);
            Console.WriteLine(simpleInterest.AccruedInterest);
        }
    }
}
