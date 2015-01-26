using System;


class Person
{
    /*----- FIELDS -----*/

    private string name;
    private int age;
    private string email;


    /*----- PROPERTIES -----*/

    public string Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("name", "Name cannot be empty.");
            }

            if (!PersonMethods.ValidateName(value))
            {
                throw new ArgumentException("Name should contain only Latin letters, spaces and hyphens and start with an uppercase letter.", "name");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (!PersonMethods.ValidateAge(value))
            {
                throw new ArgumentOutOfRangeException("age", "Age should be an integer between 1 and 100 inclusive.");
            }

            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (value != null && !PersonMethods.ValidateEmail(value))
            {
                throw new ArgumentException("Email could not be validated.", "email");
            }

            this.email = value;
        }
    }


    /*----- CONSTRUCTORS -----*/

    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    // required by the problem: Two constructors, the second one calls the first
    public Person(string name, int age)
        : this(name, age, null)
    {
    }


    /*----- METHODS -----*/

    public override string ToString()
    {
        return String.Format(
            "This is a person called {0}. He/she is {1} years old. His/her email address is {2}.",
            this.Name, this.Age, this.Email ?? "not set");
    }

    public void IntroducePerson()
    {
        Console.WriteLine(
            "Hi, my name is {0} and I'm {1} years old.",
            this.Name, this.Age);
    }
}
