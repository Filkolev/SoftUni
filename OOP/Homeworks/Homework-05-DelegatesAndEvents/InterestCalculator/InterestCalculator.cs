namespace _01.InterestCalculator
{
    using System;

    public delegate decimal CalculateInterest(decimal balance, decimal interestRate, int years);

    class InterestCalculator
    {
        private decimal interestRate;
        private int years;
        private CalculateInterest calculationMethod;

        public InterestCalculator(decimal moneyBalance, decimal interestRate, int years, CalculateInterest calculationMethod)
        {
            this.Balance = moneyBalance;
            this.InterestRate = interestRate;
            this.Years = years;
            this.calculationMethod = calculationMethod;
        }

        public decimal Balance { get; private set; }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interestRate", "The interest rate cannot be negative.");
                }

                this.interestRate = value;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("years", "The number of years cannot be negative.");
                }

                this.years = value;
            }
        }

        public decimal AccruedInterest
        {
            get
            {
                return this.calculationMethod(this.Balance, this.InterestRate, this.Years);
            }
        }
    }
}
