namespace _04.CompanyHierarchy.Contracts
{
    using People;

    interface IEmployee : IPerson
    {
        Department Department { get; }

        decimal Salary { get; }
    }
}
