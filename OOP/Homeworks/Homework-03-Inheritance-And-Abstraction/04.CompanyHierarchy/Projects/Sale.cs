namespace _04.CompanyHierarchy.Projects
{
    using System;
    using Contracts;

    class Sale : ISale
    {
        private string productName;
        private decimal price;

        public Sale(string productName, DateTime dateOfSale, decimal price)
        {
            this.ProductName = productName;
            this.DateOfSale = dateOfSale;
            this.Price = price;
        }

        public Sale(string productName, decimal price)
            : this(productName, DateTime.Now, price)
        {
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("productName", "Product name cannot be empty.");
                }

                this.productName = value;
            }
        }

        public DateTime DateOfSale { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Product: {0}, sold at: {1}, price: {2:c2}",
                this.ProductName,
                this.DateOfSale.Date,
                this.Price);
        }
    }
}