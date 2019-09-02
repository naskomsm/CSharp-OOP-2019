namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class PlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();

            var mainPlayer = new MainPlayer("Vercetti");
            this.players.Add(mainPlayer);
        }

        public int Count => this.players.Count - 1;

        public string Add(string name)
        {
            var player = new CivilPlayer(name);
            this.players.Add(player);

            return $"Successfully added civil player: {player.Name}!";
        }

        public IPlayer GetByName(string name)
        {
            return this.players.FirstOrDefault(x => x.Name == name);
        }

        public List<IPlayer> CivilPlayers()
        {
            return this.players.Where(x => x.GetType().Name == "CivilPlayer").ToList();
        }
    }
}
