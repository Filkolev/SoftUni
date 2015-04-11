namespace Homework_17_SOLID_Principles.Contracts
{
    using System;
    using Models;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        ILayout Layout { get; }

        void Append(DateTime date, ReportLevel reportLevel, string message);
    }
}
