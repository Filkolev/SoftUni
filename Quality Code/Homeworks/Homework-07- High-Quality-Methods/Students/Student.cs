namespace Students
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string address;
        private DateTime dateOfBirth;

        public Student(string firstName, string lastName, string address, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
        }

        public Student(string firstName, string lastName, string address, DateTime dateOfBirth, string additionalInfo)
            : this(firstName, lastName, address, dateOfBirth)
        {
            this.AdditionalInfo = additionalInfo;
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
                    throw new ArgumentNullException("firstName", "First name cannot be empty.");
                }

                this.firstName = value;
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
                    throw new ArgumentNullException("lastName", "Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("address", "Address cannot be empty.");
                }

                this.address = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                this.dateOfBirth = value;
            }
        }

        public string AdditionalInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.DateOfBirth < other.DateOfBirth;
        }
    }
}
