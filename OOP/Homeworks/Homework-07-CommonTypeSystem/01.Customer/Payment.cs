namespace _01.Customer
{
    using System;

    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
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
                    throw new ArgumentNullException(
                        "productName", 
                        "The product name cannot be empty.");
                }

                this.productName = value;
            }
        }

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
                    throw new ArgumentOutOfRangeException(
                        "price", 
                        "The product price cannot be negative.");
                }

                this.price = value;
            }
        }
    }
}
