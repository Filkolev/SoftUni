namespace Homework_17_SOLID_Principles.Models.Layouts
{
    using System;
    using Contracts;

    public class SimpleLayout : ILayout
    {
        private const string LogSimpleFormat = "{0} - {1} - {2}";

        public string FormatLog(DateTime date, ReportLevel reportLevel, string message)
        {
            string formattedLog = string.Format(LogSimpleFormat + Environment.NewLine, date, reportLevel, message);

            return formattedLog;
        }
    }
}
