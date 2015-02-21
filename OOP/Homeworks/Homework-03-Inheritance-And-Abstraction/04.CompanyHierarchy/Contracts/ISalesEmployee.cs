namespace _04.CompanyHierarchy.Contracts
{
    using System.Collections.Generic;

    interface ISalesEmployee : IEmployee
    {
        List<ISale> Sales { get; }
    }
}
