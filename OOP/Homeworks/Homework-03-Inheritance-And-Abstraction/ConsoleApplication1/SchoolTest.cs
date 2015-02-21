namespace School
{
    using System;
    using Entities;
    using People;

    class SchoolTest
    {
        static void Main()
        {
            Classroom newClassroom = new Classroom("12A", new Discipline("Math", 30));
            Student pesho = new Student("Pesho", 12, newClassroom);

            Console.WriteLine(
                "{0} is a student in {1}, he is number {2} in class. He studies: {3}.",
                pesho.Name,
                pesho.Class.Identifier,
                pesho.ClassNumber,
                string.Join(", ", pesho.SubjectNames));
        }
    }
}
