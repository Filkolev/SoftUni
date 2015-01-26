using System;

class OnsiteStudent : CurrentStudent
{
    private int numberOfVisits;

    public int NumberOfVisits
    {
        get { return this.numberOfVisits; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("numberOfVisits", "Number of visits cannot be negative.");
            }

            this.numberOfVisits = value;
        }
    }

    public OnsiteStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse, int numberOfVisits)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public override string ToString()
    {
        string result = base.ToString();
        result += "Number of visits: " + this.NumberOfVisits + "\r\n";

        return result;
    }
}

