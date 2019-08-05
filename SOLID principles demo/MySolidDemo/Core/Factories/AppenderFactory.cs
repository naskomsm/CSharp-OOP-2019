namespace MySolidDemo.Core.Factories
{
    using MySolidDemo.Appenders.Contracts;
    using MySolidDemo.Appenders.Types;
    using MySolidDemo.Core.Factories.Contracts;
    using MySolidDemo.Enumerations;
    using MySolidDemo.Layouts;
    using MySolidDemo.Layouts.Contracts;
    using MySolidDemo.Layouts.Types;
    using MySolidDemo.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public void Create(IAppender[] appenders,int numberOfAppenders)
        {
            for (int i = 0; i < numberOfAppenders; i++)
            {
                var input = Console.ReadLine().Split();

                ILayout layout = null;

                switch (input[1])
                {
                    case nameof(SimpleLayout):
                        layout = new SimpleLayout();
                        break;
                    case nameof(XmlLayout):
                        layout = new XmlLayout();
                        break;
                    default:
                        throw new ArgumentException();
                }

                IAppender appender = null;

                switch (input[0])
                {
                    case nameof(ConsoleAppender):
                        appender = new ConsoleAppender(layout);
                        break;
                    case nameof(FileAppender):
                        appender = new FileAppender(layout);
                        ((FileAppender)appender).File = new LogFile();
                        break;
                }

                if (input.Length == 3)
                {
                    ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), input[2]);
                    appender.ReportLevel = level;
                }

                appenders[i] = appender;
            }
        }
    }
}
