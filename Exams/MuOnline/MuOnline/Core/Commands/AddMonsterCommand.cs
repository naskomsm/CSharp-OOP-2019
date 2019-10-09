namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Monsters.Contracts;
    using MuOnline.Repositories.Contracts;

    public class AddMonsterCommand : ICommand
    {
        private readonly IRepository<IMonster> monsterRepository;
        private readonly IMonsterFactory monsterFactory;

        public AddMonsterCommand(IRepository<IMonster> monsterRepository, IMonsterFactory monsterFactory)
        {
            this.monsterRepository = monsterRepository;
            this.monsterFactory = monsterFactory;
        }

        public string Execute(string[] inputArgs)
        {
            string monsterType = inputArgs[0].ToLower();

            var monster = monsterFactory.Create(monsterType);

            this.monsterRepository.Add(monster);

            return $"Successfully created new {monster.GetType().Name}!";
        }
    }
}
