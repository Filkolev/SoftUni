namespace School.People
{
    using System;
    using Contracts;

    abstract class Person : IPerson
    {
        private string name;

        protected Person(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty.");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Name should be at least two characters long.", "name");
                }

                this.name = value;
            }
        }

        public string Details { get; set; }
    }
}
