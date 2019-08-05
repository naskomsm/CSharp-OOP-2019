namespace MySolidDemo.Core.Factories
{
    using MySolidDemo.Appenders.Contracts;
    using MySolidDemo.Core.Factories.Contracts;
    using MySolidDemo.Enumerations;
    using MySolidDemo.Loggers;
    using System;

    public class ReportFactory : IReportFactory
    {
        public void Create(IAppender[] appenders)
        {
            var logger = new Logger(appenders);


            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var input = command.Split('|');

                string time = input[1];
                string message = input[2];

                ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), input[0]);

                switch (level)
                {
                    case ReportLevel.CRITICAL:
                        logger.Critical(time, message);
                        break;
                    case ReportLevel.ERROR:
                        logger.Error(time, message);
                        break;
                    case ReportLevel.FATAL:
                        logger.Fatal(time, message);
                        break;
                    case ReportLevel.INFO:
                        logger.Info(time, message);
                        break;
                    case ReportLevel.WARNING:
                        logger.Warn(time, message);
                        break;
                }
            }

            Console.WriteLine(logger);
        }
    }
}
