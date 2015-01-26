using System;

class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("firstName", "First name cannot be empty");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("lastName", "Last name cannot be empty");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("age", "Age should be an integer between 0 and 100.");
            }

            this.age = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public override string ToString()
    {
        string result = String.Format("{1}, {0}\r\n", this.FirstName, this.LastName);
        result += "Age: " + this.Age + "\r\n";

        return result;
    }
}


