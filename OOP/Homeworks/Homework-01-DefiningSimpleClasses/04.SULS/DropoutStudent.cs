using System;

class DropoutStudent : Student
{
    private string dropoutReason;

    public string DropoutReason
    {
        get { return this.dropoutReason; }
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
        Console.WriteLine(this);
    }

    public override string ToString()
    {
        string result = base.ToString();
        result += "Dropout reason: " + this.DropoutReason + "\r\n";

        return result;
    }
}

