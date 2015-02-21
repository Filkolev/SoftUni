namespace _04.CompanyHierarchy
{
    using System;
    using People;
    using Projects;

    class CompanyHierarchyTest
    {
        static void Main()
        {
            SalesEmployee retailer = new SalesEmployee(12, "Podlizurko", "Dreben", Department.Marketing, 500, new Sale("iPod", 340));

            Employee[] employees = 
            {
                retailer,
                new Manager(28882, "Shefa", "Na firmata", Department.Marketing, 5500, retailer),
                new Developer(534, "Pesho", "Goshev", Department.Production, 2300, new Project("Project")),
                new SalesEmployee(342, "Ivan", "Grigorov", Department.Accounting, 1200, new Sale("Nishto", 0)), 
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
