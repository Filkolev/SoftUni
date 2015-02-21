namespace _02.Human_Student_Worker
{
    using System;
    using System.Text.RegularExpressions;

    class Student : Human
    {
        private const string FacultyNumberMatcher = @"[a-zA-Z0-9]{5,10}";
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (!ValidateFacultyNumber(value))
                {
                    throw new ArgumentException(
                        "Faculty number should be between 5 and 10 symbols, letters and digits only.", "facultyNumber");
                }

                this.facultyNumber = value;
            }
        }

        public static bool ValidateFacultyNumber(string number)
        {
            return Regex.IsMatch(number, FacultyNumberMatcher);
        }

        public override string ToString()
        {
            return base.ToString() + "\nFaculty number: " + this.FacultyNumber + "\n";
        }
    }
}
