namespace PlayersAndMonsters.Core
{
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;

        private CardRepository cardRepo;
        private PlayerRepository playerRepo;

        private BattleField battlefield;

        public ManagerController()
        {
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();

            this.cardRepo = new CardRepository();
            this.playerRepo = new PlayerRepository();

            this.battlefield = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepo.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepo.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepo.Find(username);
            var card = this.cardRepo.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playerRepo.Find(attackUser);
            var enemyPlayer = this.playerRepo.Find(enemyUser);

            if (attackPlayer == null || enemyPlayer == null)
            {
                return $"Player cannot be null";
            }

            this.battlefield.Fight(attackPlayer, enemyPlayer);

            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepo.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Cards.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
