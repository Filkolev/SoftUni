using System;

class DropoutStudent : Student
{
    private string dropoutReason;

    public string DropoutReason
    {
        get
        {
            return this.dropoutReason;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("dropoutReason", "Dropout reason cannot be empty.");
            }

            this.dropoutReason = value;
        }
    }

    public DropoutStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string dropoutReason)
        : base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.DropoutReason = dropoutReason;
    }

    public void Reapply()
    {
        Console.WriteLine("Name: {1}, {0}", this.FirstName, this.LastName);
        Console.WriteLine("Age: {0}", this.Age);
        Console.WriteLine("Student Number: {0}", this.StudentNumber);
        Console.WriteLine("Average Grade: {0:f2}", this.AverageGrade);
        Console.WriteLine("Dropout Reason: {0}", this.DropoutReason);
    }

    public override string ToString()
    {
        string result = base.ToString();
        result += "Dropout reason: " + this.DropoutReason + "\r\n";

        return result;
    }
}

