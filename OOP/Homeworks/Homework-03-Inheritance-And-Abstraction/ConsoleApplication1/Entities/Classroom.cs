namespace School.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;
    using Data;

    class Classroom : IClassroom
    {
        private const string IdentifierMatcher = @"\d{1,2}[a-zA-Z]";
        private string identifier;
        private List<IDiscipline> disciplines;

        public Classroom(string identifier, List<IDiscipline> disciplines)
        {
            this.Identifier = identifier;
            this.Disciplines = disciplines;
            SchoolData.AddClassroomToDatabase(this);
        }

        public Classroom(string identifier, IDiscipline discipline)
            : this(identifier, new List<IDiscipline>() { discipline })
        {
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("identifier", "Class identifier cannot be empty.");
                }

                if (!Regex.IsMatch(value, IdentifierMatcher))
                {
                    throw new ArgumentException("Class identifier should consist of 1 or 2 digits followed by a Latin letter", "identifier");
                }

                this.identifier = value;
            }
        }

        public List<IStudent> Students
        {
            get
            {
                return SchoolData.GetStudentsByClassroom(this);
            }
        }

        public List<ITeacher> Teachers
        {
            get
            {
                return SchoolData.GetTeachersByClassroom(this);
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
                    throw new ArgumentOutOfRangeException("disciplines", "Classroom should have at least one discipline.");
                }

                this.disciplines = value;
            }
        }

        public string Details { get; set; }

        public void AddDisciplinesToClassroom(params IDiscipline[] newDisciplines)
        {
            this.disciplines.AddRange(newDisciplines);
        }
    }
}
