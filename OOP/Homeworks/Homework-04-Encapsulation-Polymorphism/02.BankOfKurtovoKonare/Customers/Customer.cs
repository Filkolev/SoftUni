namespace _02.BankOfKurtovoKonare.Customers
{
    using System;
    using Contracts;

    class Customer : ICustomer
    {
        private string name;

        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name", "Customer's name cannot be empty.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("The customer's name should be at least 3 characters long.", "name");
                }

                this.name = value;
            }
        }

        public CustomerType CustomerType { get; set; }
    }
}
