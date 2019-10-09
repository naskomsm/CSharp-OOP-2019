namespace MuOnline.Repositories
{
    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroRepository;

        public HeroRepository()
        {
            this.heroRepository = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository
            => this.heroRepository.AsReadOnly();

        public void Add(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            this.heroRepository.Add(hero);
        }

        public string Remove(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            if (this.heroRepository.Contains(hero))
            {
                throw new InvalidOperationException("No such hero in repository!");
            }

            this.heroRepository.Remove(hero);

            return $"Removed {hero.GetType().Name} from repository";
        }

        public IHero Get(string heroName)
        {
            if (heroName == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            var searchedHero = this.heroRepository.FirstOrDefault(x => ((IIdentifiable)x).Username == heroName); 

            return searchedHero;
        }
    }
}
