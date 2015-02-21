namespace _02.BankOfKurtovoKonare.Contracts
{
    using Customers;

    interface ICustomer
    {
        string Name { get; }

        CustomerType CustomerType { get; }
    }
}
