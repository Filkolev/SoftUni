namespace Homework_17_SOLID_Principles.Models.Appenders
{
    using System;
    using Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string formattedLogEntry = this.GetFormattedLogEntry(date, reportLevel, message);

                Console.Write(formattedLogEntry);
            }
        }
    }
}