namespace Models
{
    using System;
    using System.Text;
    using Interfaces;

    class Rent : IRent
    {
        private IItem itemRented;

        public Rent(IItem item, DateTime rentDate, DateTime returnDeadline)
        {
            this.ItemRented = item;
            this.DateOfRent = rentDate;
            this.ReturnDeadline = returnDeadline;
        }

        public Rent(IItem item, DateTime rentDate) :
            this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(IItem item) :
            this(item, DateTime.Now)
        {
        }

        public IItem ItemRented
        {
            get
            {
                return this.itemRented;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("itemRented", "The rented item cannot be empty.");
                }

                this.itemRented = value;
            }
        }

        public RentStatus RentStatus
        {
            get
            {
                if (this.ReturnDate > DateTime.MinValue)
                {
                    return RentStatus.Returned;
                }

                return this.ReturnDeadline >= DateTime.Now ? RentStatus.Pending : RentStatus.Overdue;
            }
        }

        public DateTime DateOfRent { get; private set; }

        public DateTime ReturnDeadline { get; private set; }

        public DateTime ReturnDate { get; private set; }

        public decimal RentFine
        {
            get
            {
                return this.CalculateRentFine();
            }
        }

        public decimal CalculateRentFine()
        {
            DateTime dateOfCheck = this.ReturnDate;
            if (this.ReturnDate == DateTime.MinValue)
            {
                dateOfCheck = DateTime.Now;
            }

            int daysLate = (dateOfCheck - this.ReturnDeadline).Days;

            decimal fine = this.ItemRented.Price * daysLate / 100;

            return fine;
        }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("- Rent ");
            result.AppendLine(this.RentStatus.ToString());

            result.Append(this.ItemRented);

            result.Append("Rent fine: ");
            result.AppendLine(string.Format("{0:f2}", this.RentFine));

            return result.ToString();
        }
    }
}
