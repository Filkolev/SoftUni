using System;
using System.Collections.Generic;
using System.Linq;

class SULSTest
{
    static void Main()
    {
        Trainer regularTrainer = new Trainer("Gogo", "Strogiya", 60);
        JuniorTrainer juniorTrainer = new JuniorTrainer("Asistent", "Pomagachev", 24);
        SeniorTrainer seniorTrainer = new SeniorTrainer("Golemec", "Shisharkov", 42);
        regularTrainer.CreateCourse("OOP");
        juniorTrainer.CreateCourse("QPC");
        seniorTrainer.CreateCourse("ABC");
        seniorTrainer.DeleteCourse("DEF");
        Console.WriteLine();

        DropoutStudent applicant = new DropoutStudent("Otpadnal", "Student", 21, 1222, 3.03, "Nyama bira!!!");
        applicant.Reapply();
        Console.WriteLine();

        var people = new List<Person>
        {
            new Person("Georgi", "Georgiev", 20),
            new Trainer("Ivan", "Ivanov", 28),
            new JuniorTrainer("Ivan", "Ivanov Jr.", 19),
            new SeniorTrainer("Ivan", "Ivanov Sr.", 35),
            new Student("Pesho", "Peshev", 22, 1234, 5.75),
            new DropoutStudent("Misho", "Mihaylov", 25, 1234, 3.5, "Too few women on campus."),
            new GraduateStudent("Golemets", "Golemiya", 31, 1234, 5.25),
            new CurrentStudent("Stamat", "Botusharov", 23, 1234, 3.25, "OOP"),
            new OnlineStudent("Myrzeliv", "Myrzelivets", 21, 1234, 2.5, "OOP"),
            new OnsiteStudent("Svetlin", "Nakov", 34, 1234, 6, "OOP", 15),
            new CurrentStudent("Irokentij", "Portokalov", 43, 1234, 4.25, "QPC"),
            new OnlineStudent("Onufrij", "Popryckov", 63, 1234, 5.15, "QPC"),
            new OnsiteStudent("Maria", "Ivanova", 19, 1234, 5.86, "QPC", 12)
        };


        //people.Add(new Person("", "Georgiev", 20));
        //people.Add(new Person("Georgi", " ", 10));
        //people.Add(new Person("Georgi", "Georgiev", -2));
        //people.Add(new Person("Georgi", "Georgiev", 101));
        //people.Add(new Student("Pesho", "Peshev", 22, 11, 2.5));
        //people.Add(new Student("Pesho", "Peshev", 22, 1202022, 2.5));
        //people.Add(new Student("Pesho", "Peshev", 22, 1234, 1.9));
        //people.Add(new Student("Pesho", "Peshev", 22, 1234, 7.5));
        //people.Add(new DropoutStudent("Misho", "Mihaylov", 25, 1234, 3.5, ""));
        //people.Add(new CurrentStudent("Stamat", "Botusharov", 23, 1234, 3.25, " "));

        List<CurrentStudent> currentStudents = people.Where(a => a is CurrentStudent).ToList().Cast<CurrentStudent>().ToList();
        var sortedCurrentStudents = currentStudents.OrderBy(a => a.AverageGrade);

        Console.WriteLine("List of current students (sorted by average grade):");
        Console.WriteLine();

        foreach (var student in sortedCurrentStudents)
        {
            Console.WriteLine(student);
        }
    }
}
