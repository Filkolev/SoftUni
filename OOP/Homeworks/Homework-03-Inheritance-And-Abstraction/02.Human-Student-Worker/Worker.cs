namespace _02.Human_Student_Worker
{
    using System;

    class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salaryPerWeek, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = salaryPerWeek;
            this.workHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "weekSalary", "Week salary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentOutOfRangeException(
                        "workHoursPerDay", "Work hours per day should be in the range [0 ... 24].");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            if (this.workHoursPerDay == 0)
            {
                return 0;
            }

            double workHoursPerWeek = 5 * this.WorkHoursPerDay;
            decimal hourSalary = this.WeekSalary / (decimal)workHoursPerWeek;

            return hourSalary;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += string.Format(
                "\nWeek salary: {0}\nWork hours per day: {1}\nHourly salary: {2}\n", 
                this.weekSalary, 
                this.workHoursPerDay, 
                this.MoneyPerHour());

            return result;
        }
    }
}
