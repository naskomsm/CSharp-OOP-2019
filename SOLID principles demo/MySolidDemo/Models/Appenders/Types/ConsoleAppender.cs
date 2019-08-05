namespace MySolidDemo.Appenders.Types
{
    using MySolidDemo.Enumerations;
    using MySolidDemo.Layouts.Contracts;
    using MySolidDemo.Models.Appenders;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                Console.WriteLine(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }
    }
}
