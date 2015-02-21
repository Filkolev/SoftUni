namespace Models
{
    using System;
    using System.Globalization;
    using System.Text;
    using Interfaces;

    class Sale : ISale
    {
        private IItem itemSold;

        public Sale(IItem itemSold, DateTime dateOfPurchase)
        {
            this.ItemSold = itemSold;
            this.DateOfPurchase = dateOfPurchase;
        }

        public Sale(IItem itemSold)
            : this(itemSold, DateTime.Now)
        {
        }

        public IItem ItemSold
        {
            get
            {
                return this.itemSold;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("itemSold", "The item sold cannot be null.");
                }

                this.itemSold = value;
            }
        }

        public DateTime DateOfPurchase { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("- Sale ");
            result.AppendLine(this.DateOfPurchase.Date.ToString(CultureInfo.InvariantCulture));

            result.Append(this.ItemSold);

            return result.ToString();
        }
    }
}
