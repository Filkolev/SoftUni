namespace School.Contracts
{
    using System.Collections.Generic;

    interface IClassroom : IDescribable
    {
        string Identifier { get; }

        List<IStudent> Students { get; }

        List<ITeacher> Teachers { get; }

        List<IDiscipline> Disciplines { get; }

        void AddDisciplinesToClassroom(params IDiscipline[] newDisciplines);
    }
}
