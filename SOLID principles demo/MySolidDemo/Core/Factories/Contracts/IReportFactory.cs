namespace MySolidDemo.Core.Factories.Contracts
{
    using MySolidDemo.Appenders.Contracts;

    public interface IReportFactory
    {
        void Create(IAppender[] appenders);
    }
}
