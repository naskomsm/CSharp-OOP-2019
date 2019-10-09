using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AddHeroCommand : ICommand
    {
        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> heroRepository, IHeroFactory heroFactory)
        {
            this.heroRepository = heroRepository;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var heroType = inputArgs[0].ToLower();
            var userName = inputArgs[1];

            var hero = heroFactory.Create(heroType, userName);

            this.heroRepository.Add(hero);

            return $"Successfully created new {hero.GetType().Name}!";
        }
    }
}
