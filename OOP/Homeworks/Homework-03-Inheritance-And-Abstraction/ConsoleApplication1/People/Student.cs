namespace School.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;

    class Student : Person, IStudent
    {
        private int classNumber;
        private IClassroom classroom;

        public Student(string name, int classNumber, IClassroom classroom, string details = null)
            : base(name, details)
        {
            this.ClassNumber = classNumber;
            this.Class = classroom;
            SchoolData.AddStudentToDatabase(this);
        }

        public IClassroom Class
        {
            get
            {
                return this.classroom;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("classroom", "Classroom cannot be omitted.");
                }

                this.classroom = value;
            }
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("classNumber", "Class number should be greater than zero.");
                }

                this.classNumber = value;
            }
        }

        public List<IDiscipline> Disciplines
        {
            get
            {
                return this.Class.Disciplines;
            }
        }

        public List<string> SubjectNames
        {
            get
            {
                HashSet<string> result = new HashSet<string>();

                foreach (var discipline in this.Disciplines)
                {
                    result.Add(discipline.Name);
                }

                return result.ToList();
            }
        }

        public List<ITeacher> Teachers
        {
            get
            {
                return SchoolData.GetTeachersByClassroom(this.Class);
            }
        }
    }
}
