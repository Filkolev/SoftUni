namespace _02.BankOfKurtovoKonare.Contracts
{
    interface IAccount
    {
        ICustomer Customer { get; }

        decimal Balance { get; }

        decimal MonthlyInterestRate { get; }

        decimal CalculateInterest(int periodInMonths);
    }
}
