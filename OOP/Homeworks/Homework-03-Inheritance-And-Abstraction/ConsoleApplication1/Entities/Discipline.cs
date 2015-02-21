namespace School.Entities
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data;

    internal class Discipline : IDiscipline
    {
        private string name;
        private int numberOfLectures;

        public Discipline(string name, int numberOfLectures)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            SchoolData.AddDisciplineToDatabase(this);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Discipline name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("numberOfLectures", "The number of lectures should be greater than zero.");
                }

                this.numberOfLectures = value;
            }
        }

        public List<ITeacher> Teachers
        {
            get
            {
                return SchoolData.GetTeachersByDiscipline(this);
            }
        }

        public List<IClassroom> Classrooms
        {
            get
            {
                return SchoolData.GetClassroomsByDiscipline(this);
            }
        }

        public string Details { get; set; }
    }
}
