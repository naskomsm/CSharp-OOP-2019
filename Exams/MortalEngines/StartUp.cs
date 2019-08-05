using MortalEngines.Core.Contracts;
using MortalEngines.Entities.Machines;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}