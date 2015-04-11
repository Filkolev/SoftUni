namespace Homework_17_SOLID_Principles.Contracts
{
    using System;
    using Models;

    public interface ILayout
    {
        string FormatLog(DateTime date, ReportLevel reportLevel, string message);
    }
}
