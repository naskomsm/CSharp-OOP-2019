namespace MuOnline.Core.Factories
{
    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Monsters;
    using MuOnline.Models.Monsters.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x=>typeof(IMonster).IsAssignableFrom(x)) // ???
                .FirstOrDefault(x => x.Name.ToLower() == monsterType);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid monster type!");
            }

            var instance = (IMonster)Activator.CreateInstance(type);

            return instance;
        }
    }
}
