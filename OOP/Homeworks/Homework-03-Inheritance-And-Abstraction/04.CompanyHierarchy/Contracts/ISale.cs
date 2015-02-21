namespace _04.CompanyHierarchy.Contracts
{
    using System;

    interface ISale
    {
        string ProductName { get; }

        DateTime DateOfSale { get; }

        decimal Price { get; }
    }
}
