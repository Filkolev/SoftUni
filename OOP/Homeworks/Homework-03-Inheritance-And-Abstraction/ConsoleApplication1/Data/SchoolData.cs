namespace School.Data
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    static class SchoolData
    {
        private static List<IStudent> students = new List<IStudent>();
        private static List<ITeacher> teachers = new List<ITeacher>();
        private static List<IClassroom> classrooms = new List<IClassroom>();
        private static List<IDiscipline> disciplines = new List<IDiscipline>();

        public static void AddStudentToDatabase(IStudent student)
        {
            if (!ValidateStudentNumber(student))
            {
                throw new ArgumentException("Duplicate class number. Students in a class should have unique numbers.", "studentNumber");
            }

            students.Add(student);
        }

        public static void AddClassroomToDatabase(IClassroom classroom)
        {
            if (!ValidateClassroomIdentifier(classroom))
            {
                throw new ArgumentException("Duplicate classroom identifier.", "identifier");
            }

            classrooms.Add(classroom);
        }

        public static void AddTeacherToDatabase(ITeacher teacher)
        {
            teachers.Add(teacher);
        }

        public static void AddDisciplineToDatabase(IDiscipline discipline)
        {
            disciplines.Add(discipline);
        }

        public static List<ITeacher> GetTeachersByClassroom(IClassroom classroom)
        {
            var disciplines = classroom.Disciplines;
            var result = new List<ITeacher>();

            foreach (var discipline in disciplines)
            {
                result.AddRange(GetTeachersByDiscipline(discipline));
            }

            return result;
        }

        public static List<ITeacher> GetTeachersByDiscipline(IDiscipline discipline)
        {
            var result = new List<ITeacher>();

            foreach (var dis in disciplines)
            {
                if (dis.Name == discipline.Name)
                {
                    result.AddRange(dis.Teachers);
                }
            }

            return result;
        }

        public static List<IClassroom> GetClassroomsByDiscipline(IDiscipline discipline)
        {
            var result = new List<IClassroom>();

            foreach (var classroom in classrooms)
            {
                foreach (var dis in classroom.Disciplines)
                {
                    if (dis.Name != discipline.Name)
                    {
                        continue;
                    }

                    result.Add(classroom);
                    break;
                }
            }

            return result;
        }

        public static List<IStudent> GetStudentsByClassroom(IClassroom classroom)
        {
            var result = new List<IStudent>();

            foreach (var student in students)
            {
                if (student.Class.Identifier == classroom.Identifier)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public static List<IClassroom> GetClassroomsByTeacher(ITeacher teacher)
        {
            List<IClassroom> result = new List<IClassroom>();

            foreach (var discipline in teacher.Disciplines)
            {
                result.AddRange(GetClassroomsByDiscipline(discipline));
            }

            return result;
        }

        public static bool ValidateStudentNumber(IStudent student)
        {
            var studentsInClass = GetStudentsByClassroom(student.Class);

            foreach (var currentStudent in studentsInClass)
            {
                if (currentStudent.ClassNumber == student.ClassNumber)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateClassroomIdentifier(IClassroom newClassroom)
        {
            foreach (var classroom in classrooms)
            {
                if (newClassroom.Identifier == classroom.Identifier)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
