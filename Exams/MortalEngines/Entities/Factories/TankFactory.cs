namespace MortalEngines.Entities.Factories
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class TankFactory
    {
        public ITank CreateTank(string name, double attackPoints, double defensePoints)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Tank");

            var instance = (ITank)Activator.CreateInstance(type, name, attackPoints, defensePoints);

            return instance;
        }
    }
}
