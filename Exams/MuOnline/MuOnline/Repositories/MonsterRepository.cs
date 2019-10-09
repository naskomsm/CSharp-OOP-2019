namespace MuOnline.Repositories
{
    using MuOnline.Models.Monsters.Contracts;
    using MuOnline.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MonsterRepository : IRepository<IMonster>
    {
        private readonly List<IMonster> monsterRepository;

        public MonsterRepository()
        {
            this.monsterRepository = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository
            => this.monsterRepository.AsReadOnly();

        public void Add(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            this.monsterRepository.Add(monster);
        }

        public string Remove(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            if (this.monsterRepository.Contains(monster))
            {
                throw new InvalidOperationException("No such monster in repository!");
            }

            return $"Removed {monster.GetType().Name} from repository";
        }

        public IMonster Get(string monsterName)
        {
            if (monsterName == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            var searchedMonster = this.monsterRepository.FirstOrDefault(x => x.GetType().Name == monsterName);

            return searchedMonster;
        }
    }
}
