namespace _04.CompanyHierarchy.Contracts
{
    using System;
    using Projects;

    internal interface IProject
    {
        string ProjectName { get; }

        DateTime ProjectStartDate { get; }

        string Details { get; }

        ProjectState ProjectState { get; }
    }
}
