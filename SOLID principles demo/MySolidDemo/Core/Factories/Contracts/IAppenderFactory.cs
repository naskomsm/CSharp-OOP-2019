namespace MySolidDemo.Core.Factories.Contracts
{
    using MySolidDemo.Appenders.Contracts;

    public interface IAppenderFactory
    {
        void Create(IAppender[] appenders, int numberOfAppenders);
    }
}
