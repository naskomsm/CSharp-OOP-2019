namespace AnimalCentre.Core.Factories
{
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AnimalFactory
    {
        public IAnimal Create(string type, string name, int energy, int happiness, int procedureTime)
        {
            var typeAnimal = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var instance = (IAnimal)Activator.CreateInstance(typeAnimal,new object[] { name,energy,happiness,procedureTime});

            return instance;
        }
    }
}
