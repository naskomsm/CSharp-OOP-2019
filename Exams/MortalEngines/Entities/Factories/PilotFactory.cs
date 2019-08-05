namespace MortalEngines.Entities.Factories
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PilotFactory
    {
        public IPilot CreatePilot(string name)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Pilot");
            
            var instance = (IPilot)Activator.CreateInstance(type, name);
            
            return instance;
        }
    }
}
