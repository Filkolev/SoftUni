namespace _03.Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentTest
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Adam", "Bishop", 17, 123413, 2, new List<int>() { 2, 3, 4, 5, 6 }, "02-955-22-22", "a.bishop@abv.bg"),
                new Student("Ivan", "Georgiev", 22, 123410, 3, new List<int>() { 6 }, "+359-955-22-22", "a.bishop@gmail.bg"),
                new Student("Georgi", "Stoimenov", 25, 123414, 4, new List<int>() { 2, 2 }, "+359223333", "a.bishop@abv.bg"),
                new Student("Steve", "Balmer", 18, 123415, 5, new List<int>() { 3, 4, 5 }, "0888000000", "a.bishop@abv.bg"),
                new Student("Pesho", "Peshev", 20, 123416, 6, new List<int>() { 5, 6 }, "+359888000000", "p.peshev@abv.bg"),
                new Student("Gosho", "Ivanov", 23, 123418, 2, new List<int>() { 2, 3 }, "02-245-22-22", "g.ivanov@mail.bg"),
                new Student("Dimitar", "Uzunov", 27, 123499, 2, new List<int>() { 2, 3, 4 }, "02-955-223-22", "dimitar.uzunov@yahoo.com"),
                new Student("Ivaylo", "Ivanov", 15, 123455, 4, new List<int>() { 4, 5, 6 }, "60-955-22-22", "iv.ivanov@harvard.edu"),
                new Student("Petar", "Petkov", 29, 123444, 6, new List<int>() { 2, 5, 6 }, "68-955-22-22", "petarpetkov@abv.bg"),
                new Student("Ivan", "Alexandrov", 26, 123441, 8, new List<int>() { 2, 3, 6 }, "55-955-22-22", "iv.alexandrov@google.bg"),
                new Student("Andrey", "Blagoev", 17, 123414, 3, new List<int>() { 4, 5, 6 }, "33-955-22-22", "andrey@mail.ru"),
                new Student("Tom", "Tucker", 18, 123410, 1, new List<int>() { 5, 6 }, "22-955-22-22", "a.bishop@abv.bg"),
                new Student("Peter", "Griffin", 21, 123412, 5, new List<int>() { 2, 2, 3, 4, 5, 6 }, "11-955-22-22", "d.bishop@abv.bg"),
                new Student("Sam", "Peters", 20, 123415, 3, new List<int>() { 2, 3, 5, 6 }, "05-955-22-22", "g.bishop@abv.bg"),
                new Student("Petya", "Popova", 19, 123417, 2, new List<int>() { 2, 3, 4, 5, 6 }, "30-955-22-22", "j.bishop@abv.bg"),
                new Student("Alex", "Ivanov", 22, 123422, 6, new List<int>() { 2, 6 }, "56-955-22-22", "a.ivanov@gmail.com"),
            };

            // Problem 4
            var studentsInGroup2 =
                students.Where(student => student.GroupNumber == 2).OrderBy(student => student.FirstName);

            Console.WriteLine("Students in group 2:");
            foreach (var student in studentsInGroup2)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 5
            var studentsWithLastNamesBeforeFirstNames =
                students.Where(student => student.LastName.CompareTo(student.FirstName) == -1);
            Console.WriteLine("Students whose last names are before their first names:");
            foreach (var student in studentsWithLastNamesBeforeFirstNames)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 6
            var studentNamesAndAges =
                from student in students
                where 18 <= student.Age && student.Age <= 24
                select new { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age };

            Console.WriteLine("Students between 18 and 24 years of age:");
            foreach (var student in studentNamesAndAges)
            {
                Console.WriteLine("{0} {1}, {2} years old", student.FirstName, student.LastName, student.Age);
            }

            Console.WriteLine();

            // Problem 7
            var sortedStudentsByNameWithMethods =
                students
                .OrderByDescending(student => student.FirstName)
                .ThenByDescending(student => student.LastName);

            Console.WriteLine("Students sorted by name (using LINQ methods):");
            foreach (var student in sortedStudentsByNameWithMethods)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var sortedStudentsByNameWithQueries =
                from student in students
                orderby student.LastName descending
                orderby student.FirstName descending
                select student;

            Console.WriteLine("Students sorted by name (using query syntax):");
            foreach (var student in sortedStudentsByNameWithQueries)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 8
            var filteredStudentsByEmailDomain = students.Where(student => student.Email.EndsWith("@abv.bg"));

            Console.WriteLine("Students with emails at abv.bg");
            foreach (var student in filteredStudentsByEmailDomain)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 9
            var studentsFromSofia =
                students.Where(student => student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2"));

            Console.WriteLine("Students from Sofia (by phone number):");
            foreach (var student in studentsFromSofia)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Problem 10
            var excellentStudents =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("Excellent students:");
            foreach (var student in excellentStudents)
            {
                Console.WriteLine(student.FullName);
            }

            Console.WriteLine();

            // Problem 11
            var studentsWithTwoLowMarks = students
                .Where(student => student.Marks.Count(mark => mark == 2) == 2)
                .Select(x => new { FullName = x.FirstName + " " + x.LastName, x.Marks });

            Console.WriteLine("Poor students (have two low marks):");
            foreach (var student in studentsWithTwoLowMarks)
            {
                Console.WriteLine(student.FullName);
            }

            Console.WriteLine();

            // Problem 12
            var studentMarksForEnrolledIn2014 = students
                .Where(student => student.FacultyNumber % 100 == 14)
                .Select(x => x.Marks);

            Console.WriteLine("Student marks (only) for students enrolled in 2014:");
            foreach (var marks in studentMarksForEnrolledIn2014)
            {
                Console.WriteLine(string.Join(", ", marks));
            }

            Console.WriteLine();
        }
    }
}
