namespace _01.Customer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private CustomerType customerType;
        private List<Payment> payments;

        public Customer(
            string firstName,
            string lastName,
            long id,
            CustomerType customerType,
            params Payment[] payments)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
            this.CustomerType = customerType;
            this.Payments = new List<Payment>(payments);
        }

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            long id,
            CustomerType customerType,
            params Payment[] payments)
            : this(firstName, lastName, id, customerType, payments)
        {
            this.MiddleName = middleName;
        }

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            long id,
            CustomerType customerType,
            string permanentAddress,
            string mobilePhone,
            string email,
            params Payment[] payments)
            : this(firstName, middleName, lastName, id, customerType, payments)
        {
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "firstName",
                        "THe customer's first name cannot be empty.");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "lastName",
                        "The customer's last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public long Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 1000000000 || 9999999999 < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "id",
                        "The id of the customer should be a 10-digit number.");
                }

                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }

            set
            {
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }

            set
            {
                this.customerType = value;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                return new List<Payment>(this.payments);
            }

            private set
            {
                this.payments = value;
            }
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return customer1.Equals(customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !customer1.Equals(customer2);
        }

        public void AddNewPayment(Payment payment)
        {
            this.payments.Add(payment);
        }

        public override bool Equals(object obj)
        {
            Customer otherCustomer = (Customer)obj;
            if (this.Id == otherCustomer.Id)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Id.GetHashCode();
        }

        public object Clone()
        {
            Payment[] copyOfPayments = this.payments.ToArray();
            Customer clonedCustomer = new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.CustomerType,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                copyOfPayments);

            return clonedCustomer;
        }

        public int CompareTo(Customer otherCustomer)
        {
            string fullName = string.Format("{0} {1}", this.FirstName, this.LastName);
            string otherCustomerFullName = string.Format("{0} {1}", otherCustomer.FirstName, otherCustomer.LastName);

            if (fullName == otherCustomerFullName)
            {
                return this.Id.CompareTo(otherCustomer.Id);
            }

            return fullName.CompareTo(otherCustomerFullName);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Customer: {0}", this.FirstName));

            if (!string.IsNullOrWhiteSpace(this.MiddleName))
            {
                result.AppendFormat(" {0}", this.MiddleName);
            }

            result.AppendLine(string.Format(" {0}", this.LastName));
            result.AppendLine(string.Format("ID: {0}", this.Id));
            result.AppendLine(string.Format("Type: {0}", this.CustomerType));

            if (!string.IsNullOrWhiteSpace(this.PermanentAddress))
            {
                result.AppendLine(string.Format("Address: {0}", this.PermanentAddress));
            }

            if (!string.IsNullOrWhiteSpace(this.MobilePhone))
            {
                result.AppendLine(string.Format("Phone: {0}", this.MobilePhone));
            }

            if (!string.IsNullOrWhiteSpace(this.Email))
            {
                result.AppendLine(string.Format("Email: {0}", this.Email));
            }

            result.AppendLine(string.Format("Number of purchases: {0}", this.Payments.Count));

            return result.ToString();
        }
    }
}