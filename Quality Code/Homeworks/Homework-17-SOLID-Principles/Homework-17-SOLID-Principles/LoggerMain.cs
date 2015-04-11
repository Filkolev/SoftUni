namespace Homework_17_SOLID_Principles
{
    using Contracts;
    using Models;
    using Models.Appenders;
    using Models.Layouts;

    public class LoggerMain
    {
        static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "../../log.txt";

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");

            var xmlLayout = new XmlLayout();
            consoleAppender = new ConsoleAppender(xmlLayout);
            logger = new Logger(consoleAppender);
            logger.Fatal("mscorlib.dll does not respond");
            logger.Critical("No connection string found in App.config");

            consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;
            logger = new Logger(consoleAppender);


            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}