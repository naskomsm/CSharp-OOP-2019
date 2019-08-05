namespace MySolidDemo.Appenders.Contracts
{
    using MySolidDemo.Enumerations;
    using MySolidDemo.Layouts.Contracts;

    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string date, ReportLevel level, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
