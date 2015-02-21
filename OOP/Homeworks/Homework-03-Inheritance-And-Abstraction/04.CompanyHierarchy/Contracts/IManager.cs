namespace _04.CompanyHierarchy.Contracts
{
    using System.Collections.Generic;

    interface IManager : IEmployee
    {
        List<IEmployee> EmployeesManaged { get; }
    }
}
