namespace _04.CompanyHierarchy.Contracts
{
    interface ICustomer : IPerson
    {
        decimal NetSpendingAmount { get; }
    }
}
