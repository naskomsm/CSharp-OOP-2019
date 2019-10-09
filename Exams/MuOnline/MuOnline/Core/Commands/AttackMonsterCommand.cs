using MuOnline.Core.Commands.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AttackMonsterCommand : ICommand
    {
        private const string commandMessagge = "{0} is dead!";

        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository, IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string heroUsername = inputArgs[0];
            string monsterName = inputArgs[1];

            var hero = heroRepository.Get(heroUsername);
            var monster = monsterRepository.Get(monsterName);

            // fight logic 
            while (hero.IsAlive && monster.IsAlive)
            {
                hero.TakeDamage(monster.AttackPoints);
                if (!hero.IsAlive)
                {
                    break;
                }

                var exp = monster.TakeDamage(hero.TotalAttackPoints);
                ((IProgress)hero).AddExperience(exp);
            }


            return string.Format(commandMessagge, hero.IsAlive ? monster.GetType().Name : heroUsername);// here is the problem ;c
        }
    }
}
