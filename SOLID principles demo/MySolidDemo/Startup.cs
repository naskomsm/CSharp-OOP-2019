namespace MySolidDemo
{
    using MySolidDemo.Core.Engine;

    public class Startup
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
