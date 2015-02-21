namespace _04.CompanyHierarchy.Contracts
{
    using System.Collections.Generic;

    interface IDeveloper : IEmployee
    {
        List<IProject> Projects { get; }
    }
}
