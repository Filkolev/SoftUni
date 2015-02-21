namespace School.Contracts
{
    using System.Collections.Generic;

    interface ITeacher : IPerson
    {
        List<IClassroom> Classrooms { get; }

        List<IDiscipline> Disciplines { get; }

        List<IStudent> Students { get; }
    }
}
