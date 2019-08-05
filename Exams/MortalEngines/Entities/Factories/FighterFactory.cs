namespace MortalEngines.Entities.Factories
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FighterFactory
    {
        public IFighter CreateFighter(string name, double attackPoints, double defensePoints)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Fighter");

            var instance = (IFighter)Activator.CreateInstance(type, name, attackPoints, defensePoints);
            return instance;
        }
    }
}
