using System;

class CurrentStudent : Student
{
    private string currentCourse;

    public string CurrentCourse
    {
        get { return this.currentCourse; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("currentCourse", "Current course cannot be empty.");
            }

            this.currentCourse = value;
        }
    }

    public CurrentStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse)
        : base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.CurrentCourse = currentCourse;
    }

    public override string ToString()
    {
        string result = base.ToString();
        result += "Current course: " + this.CurrentCourse + "\r\n";

        return result;
    }
}

