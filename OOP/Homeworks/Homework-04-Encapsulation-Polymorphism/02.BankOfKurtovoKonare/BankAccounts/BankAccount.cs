namespace _02.BankOfKurtovoKonare.BankAccounts
{
    using System;
    using Contracts;

    abstract class BankAccount : IAccount, IDepositable
    {
        private ICustomer customer;
        private decimal monthlyInterestRate;

        protected BankAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public ICustomer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("customer", "Customer cannot be empty.");
                }

                this.customer = value;
            }
        }

        public decimal Balance { get; protected set; }

        public decimal MonthlyInterestRate
        {
            get
            {
                return this.monthlyInterestRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("monthlyInterestRate", "The monthly interest rate cannot be negative.");
                }

                this.monthlyInterestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int periodInMonths)
        {
            decimal interest = this.Balance * (1 + (this.MonthlyInterestRate * periodInMonths));

            return interest;
        }

        public void DepositAmountToAccount(decimal amountToDeposit)
        {
            this.Balance += amountToDeposit;
        }
    }
}
