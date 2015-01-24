using System;

class Trainer : Person
{
    public Trainer(string firstName, string lastName, int age)
        : base(firstName, lastName, age)
    {
    }

    public void CreateCourse(string courseName)
    {
        Console.WriteLine("Course created: {0}", courseName);
    }
}

