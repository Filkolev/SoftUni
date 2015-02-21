namespace _04.CompanyHierarchy.People
{
    using System.Collections.Generic;
    using Contracts;

    class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(int id, string firstName, string lastName, Department department, decimal salary, List<ISale> sales)
            : base(id, firstName, lastName, department, salary)
        {
            this.Sales = sales;
        }

        public SalesEmployee(int id, string firstName, string lastName, Department department, decimal salary, ISale sale)
            : this(id, firstName, lastName, department, salary, new List<ISale>() { sale })
        {
        }

        public List<ISale> Sales { get; private set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format("Role: Sales Employee\n");
            result += string.Format("Sales made: {0}\n", this.Sales.Count);
            return result;
        }
    }
}
