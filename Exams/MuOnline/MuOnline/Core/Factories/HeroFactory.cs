namespace MuOnline.Core.Factories
{
    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Heroes;
    using MuOnline.Models.Heroes.HeroContracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == heroType);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid hero type!");
            }

            var instance = (Hero)Activator.CreateInstance(type, new object[] { username });

            return instance;
        }
    }
}
