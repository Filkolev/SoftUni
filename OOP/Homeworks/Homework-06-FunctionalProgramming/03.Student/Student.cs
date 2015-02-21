namespace _03.Student
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private int groupNumber;
        private IList<int> marks;
        private string phone;
        private string email;

        public Student(string firstName, string lastName, int age, int facultyNumber, int groupNumber, IList<int> marks = null, string phone = null, string email = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
            this.Phone = phone;
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
                if (!StudentUtils.IsValidName(value))
                {
                    throw new ArgumentException(
                        "First name cannot be empty. It should be between 2 and 20 symbols, start with an upper-case letter and may contain a hyphen.",
                        "firstName");
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
                if (!StudentUtils.IsValidName(value))
                {
                    throw new ArgumentException(
                        "Last name cannot be empty. It should be between 2 and 20 symbols, start with an upper-case letter and may contain a hyphen.",
                        "lastName");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0 || 120 < value)
                {
                    throw new ArgumentOutOfRangeException("age", "Age should be in the range [0 ... 120].");
                }

                this.age = value;
            }
        }

        public int FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!StudentUtils.IsValidFacultyNumber(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "facultyNumber",
                        "Faculty number should be in the range [100000 ... 999999].");
                }

                this.facultyNumber = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value < 1 || 100 < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "groupNumber",
                        "The group number should be in the range [1 ... 100].");
                }

                this.groupNumber = value;
            }
        }

        public IList<int> Marks
        {
            get
            {
                int[] marksCopy = new int[this.marks.Count];
                this.marks.CopyTo(marksCopy, 0);
                return marksCopy;
            }

            private set
            {
                this.marks = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && !StudentUtils.IsValidPhoneNumber(value))
                {
                    throw new ArgumentException("Phone number could not be validated.", "phone");
                }

                this.phone = value;
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
                if (!string.IsNullOrEmpty(value) && !StudentUtils.IsValidEmail(value))
                {
                    throw new ArgumentException("Email could not be validated.", "email");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format(
                "{0} {1} (Age: {2}, Faculty Number: {3}, Group: {4}, Phone: {5}, Email: {6} ",
                this.FirstName,
                this.LastName,
                this.Age,
                this.FacultyNumber,
                this.GroupNumber,
                this.Phone,
                this.Email);

            return result;
        }
    }
}
