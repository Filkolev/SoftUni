namespace _02.Human_Student_Worker
{
    using System;
    using System.Text.RegularExpressions;

    abstract class Human
    {
        private const string NameMatcher = @"[A-Z][a-zA-Z\-]{1,19}";

        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (!Regex.IsMatch(value, Human.NameMatcher))
                {
                    throw new ArgumentException(
                        "Name should be between 1-20 characters, can contain letters and dash and should start with a capital letter.", "firstName");
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
                if (!Regex.IsMatch(value, NameMatcher))
                {
                    throw new ArgumentException(
                        "Name should be between 1-20 characters, can contain letters and dash and should start with a capital letter.", "lastName");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}", this.FirstName, this.LastName);
        }
    }
}
