namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Models.Items.Contracts;
    using MuOnline.Repositories.Contracts;

    public class AddItemToHeroCommand : ICommand
    {
        private readonly IRepository<IItem> itemRepository;
        private readonly IRepository<IHero> heroRepository;
        private IHero givenhero;
        
        public AddItemToHeroCommand(IRepository<IItem> itemRepository, IRepository<IHero> heroRepository)
        {
            this.itemRepository = itemRepository;
            this.heroRepository = heroRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string heroName = inputArgs[0];
            string itemName = inputArgs[1].ToLower();
            
            var item = this.itemRepository.Get(itemName);
            var hero = this.heroRepository.Get(heroName);

            hero.Inventory.AddItem(item);

            return $"Succesfully added {item.GetType().Name} to {hero.GetType().Name}!";
        }
    }
}
