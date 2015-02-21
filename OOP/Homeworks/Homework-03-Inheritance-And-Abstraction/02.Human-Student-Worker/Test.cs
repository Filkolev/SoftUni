namespace _02.Human_Student_Worker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("First", "Student", "bbbbb"),
                new Student("Second", "Student", "aaaaa"),
                new Student("Third", "Student", "ccccc"),
                new Student("Fourth", "Student", "ddddd"),
                new Student("Fifth", "Student", "eeeee"),
                new Student("Sixth", "Student", "zzzzz"),
                new Student("Seventh", "Student", "ggggg"),
                new Student("Eight", "Student", "hhhhh"),
                new Student("Ninth", "Student", "iiiii"),
                new Student("Tenth", "Student", "jjjjj")

                // new Student("Invalid", "Number", "wer");
            };

            var sortedStudents = students.OrderBy(x => x.FacultyNumber);
            Console.WriteLine("Ordered students (by faculty number):");
            PrintList(sortedStudents);

            List<Worker> workers = new List<Worker>()
            {
                new Worker("First", "Worker", 23m, 16),
                new Worker("Second", "Worker", 55.99m, 24),
                new Worker("Third", "Worker", 0.1m, 0),
                new Worker("Fourth", "Worker", 100000m, 1),
                new Worker("Fifth", "Worker", 123.12m, 12),
                new Worker("Sixth", "Worker", 0.1m, 15),
                new Worker("Seventh", "Worker", 2134, 2.5),
                new Worker("Eighth", "Worker", 32, 11.5),
                new Worker("Ninth", "Worker", 100, 10),
                new Worker("Tenth", "Worker", 50, 8)

                // new Worker("Invalid", "Salary", -1, 2)
                // new Worker("Invalid", "Work Hours", 1, -1)
            };

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            Console.WriteLine("Ordered workers (by hourly salary):");
            PrintList(sortedWorkers);

            List<Human> people = new List<Human>(20);
            people.AddRange(students);
            people.AddRange(workers);

            var sortedPeople = people.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Console.WriteLine("Ordered people (by first and last name):");
            PrintList(sortedPeople);
        }

        private static void PrintList(IOrderedEnumerable<Human> list)
        {
            foreach (var human in list)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine();
        }

        private static void PrintList(IOrderedEnumerable<Student> list)
        {
            foreach (var human in list)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine();
        }

        private static void PrintList(IOrderedEnumerable<Worker> list)
        {
            foreach (var human in list)
            {
                Console.WriteLine(human);
            }

            Console.WriteLine();
        }
    }
}
