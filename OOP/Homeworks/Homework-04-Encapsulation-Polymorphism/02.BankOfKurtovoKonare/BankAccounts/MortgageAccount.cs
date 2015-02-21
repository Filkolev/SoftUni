namespace _02.BankOfKurtovoKonare.BankAccounts
{
    using System;
    using Contracts;
    using Customers;

    class MortgageAccount : BankAccount
    {
        public MortgageAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            int monthsWithFullInterest;
            decimal interest = 0;

            switch (this.Customer.CustomerType)
            {
                case CustomerType.Company:
                    int monthsWithHalfInterest = 12;
                    interest += this.Balance * (1 + (this.MonthlyInterestRate / 2 * periodInMonths));
                    monthsWithFullInterest = Math.Max(0, periodInMonths - monthsWithHalfInterest);
                    interest += base.CalculateInterest(monthsWithFullInterest);
                    break;
                case CustomerType.Individual:
                    int monthsWithNoInterest = 6;
                    monthsWithFullInterest = Math.Max(0, periodInMonths - monthsWithNoInterest);
                    interest = base.CalculateInterest(monthsWithFullInterest);
                    break;
            }

            return interest;
        }
    }
}
