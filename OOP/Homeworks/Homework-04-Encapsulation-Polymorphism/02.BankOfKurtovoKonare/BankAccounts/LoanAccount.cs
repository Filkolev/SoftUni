namespace _02.BankOfKurtovoKonare.BankAccounts
{
    using System;
    using Contracts;
    using Customers;

    class LoanAccount : BankAccount
    {
        public LoanAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            int monthsWithoutInterest = 0;
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Company:
                    monthsWithoutInterest = 2;
                    break;
                case CustomerType.Individual:
                    monthsWithoutInterest = 3;
                    break;
            }

            int monthsWithInterest = Math.Max(0, periodInMonths - monthsWithoutInterest);
            decimal interest = base.CalculateInterest(monthsWithInterest);

            return interest;
        }
    }
}
