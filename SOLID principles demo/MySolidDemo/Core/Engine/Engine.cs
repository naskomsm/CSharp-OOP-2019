namespace MySolidDemo.Core.Engine
{
    using MySolidDemo.Appenders.Contracts;
    using MySolidDemo.Core.Engine.Contracts;
    using MySolidDemo.Core.Factories;
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            // Appenders proccess
            int numberOfAppenders = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[numberOfAppenders];

            AppenderFactory appenderFactory = new AppenderFactory();
            appenderFactory.Create(appenders,numberOfAppenders);

            // Report proccess
            ReportFactory reportFactory = new ReportFactory();
            reportFactory.Create(appenders);

        }
    }
}
