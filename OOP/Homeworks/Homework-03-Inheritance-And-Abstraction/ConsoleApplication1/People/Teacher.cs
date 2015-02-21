namespace School.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;

    class Teacher : Person, ITeacher
    {
        private List<IDiscipline> disciplines;

        public Teacher(string name, List<IDiscipline> disciplines, string details = null)
            : base(name, details)
        {
            this.Disciplines = disciplines;
            SchoolData.AddTeacherToDatabase(this);
        }

        public Teacher(string name, IDiscipline discipline, string details = null)
            : this(name, new List<IDiscipline>() { discipline }, details)
        {
        }

        public List<IClassroom> Classrooms
        {
            get
            {
                return SchoolData.GetClassroomsByTeacher(this);
            }
        }

        public List<IDiscipline> Disciplines
        {
            get
            {
                IDiscipline[] result = new IDiscipline[this.disciplines.Count];
                this.disciplines.CopyTo(result);
                return result.ToList();
            }

            private set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentNullException("disciplines", "Teacher should have at least one discipline.");
                }

                this.disciplines = value;
            }
        }

        public List<IStudent> Students
        {
            get
            {
                var classrooms = this.Classrooms;
                var result = new List<IStudent>();

                foreach (var classroom in classrooms)
                {
                    result.AddRange(classroom.Students);
                }

                return result;
            }
        }

        public void AssignDiscipline(IDiscipline discipline)
        {
            this.disciplines.Add(discipline);
        }
    }
}
