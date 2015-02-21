namespace _01.Customer
{
    using System;
    using System.Linq;

    public class CustomerTest
    {
        public static void Main()
        {
            Payment hdd = new Payment("WD HDD 2TB", 189.99m);
            Payment mouse = new Payment("Mouse", 9.90m);
            Customer geek = new Customer("Bill", "Gates", 8712013812, CustomerType.Diamond, hdd, mouse);

            Payment vacation = new Payment("Vacation", 1250);
            Customer slacker = new Customer("Pesho", "Ivanov", "Georgiev", 9203131111, CustomerType.OneTime, "Sofia", null, null, vacation);

            Customer geekCopy = (Customer)geek.Clone();

            Customer anotherPesho = new Customer("Pesho", "Georgiev", 9912121212, CustomerType.Golden, hdd, vacation, mouse);

            Console.WriteLine(geek == slacker);
            Console.WriteLine(geek == geekCopy);
            Console.WriteLine();

            Customer[] customers = new[] { anotherPesho, geek, slacker };
            Array.Sort(customers);
            Console.WriteLine(string.Join("\n", customers.ToList()));
        }
    }
}
