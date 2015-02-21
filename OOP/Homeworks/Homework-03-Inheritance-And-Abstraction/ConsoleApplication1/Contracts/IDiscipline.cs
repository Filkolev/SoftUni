namespace School.Contracts
{
    using System.Collections.Generic;

    interface IDiscipline : IDescribable
    {
        string Name { get; }

        int NumberOfLectures { get; }

        List<ITeacher> Teachers { get; }

        List<IClassroom> Classrooms { get; }
    }
}
