namespace _02.BankOfKurtovoKonare.BankAccounts
{
    using Contracts;

    class DepositAccount : BankAccount, IWithdrawable
    {
        public DepositAccount(ICustomer customer, decimal balance, decimal monthlyInterestRate)
            : base(customer, balance, monthlyInterestRate)
        {
        }

        public void WithdrawMoneyFromAccount(decimal amountToWithdraw)
        {
            this.Balance -= amountToWithdraw;
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            decimal interest;

            if (0 < this.Balance && this.Balance < 1000)
            {
                interest = base.CalculateInterest(0);
            }
            else
            {
                interest = base.CalculateInterest(periodInMonths);
            }

            return interest;
        }
    }
}
