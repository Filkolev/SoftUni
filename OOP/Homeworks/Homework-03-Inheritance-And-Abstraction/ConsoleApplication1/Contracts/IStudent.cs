namespace School.Contracts
{
    using System.Collections.Generic;

    interface IStudent : IPerson
    {
        IClassroom Class { get; }

        int ClassNumber { get; }

        List<IDiscipline> Disciplines { get; }

        List<ITeacher> Teachers { get; } 
    }
}
