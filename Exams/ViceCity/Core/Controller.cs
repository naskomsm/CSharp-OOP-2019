namespace ViceCity.Core
{
    using System.Linq;
    using System.Text;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;

        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();

            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            if (type != "Rifle" && type != "Pistol")
            {
                return "Invalid gun type!";
            }

            if (type == "Rifle")
            {
                var riffle = new Rifle(name);
                this.gunRepository.Add(riffle);
            }

            else if (type == "Pistol")
            {
                var pistol = new Pistol(name);
                this.gunRepository.Add(pistol);
            }

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (!this.gunRepository.Models.Any())
            {
                return "There are no guns in the queue!";
            }

            var doesThisNameExist = this.playerRepository.GetByName(name);
            if (doesThisNameExist == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            if (name == "Vercetti")
            {
                var mainPlayer = this.playerRepository.GetByName(name);
                var gun = this.gunRepository.Models.FirstOrDefault();
                mainPlayer.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var civilPlayer = this.playerRepository.GetByName(name);
            var civilGun = this.gunRepository.Models.FirstOrDefault();
            civilPlayer.GunRepository.Add(civilGun);
            this.gunRepository.Remove(civilGun);

            return $"Successfully added {civilGun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            return this.playerRepository.Add(name);
        }

        public string Fight()
        {
            var mainPlayer = this.playerRepository.GetByName("Vercetti");
            var civilPlayers = this.playerRepository.CivilPlayers();

            this.gangNeighbourhood.Action(mainPlayer, civilPlayers);

            if (mainPlayer.LifePoints == 100 && gangNeighbourhood.CivilsKilled == 0)
            {
                return "Everything is ok!";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("A fight happened:");
            sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {gangNeighbourhood.CivilsKilled}!");
            sb.AppendLine($"Left Civil Players: {this.playerRepository.Count - gangNeighbourhood.CivilsKilled}!");

            return sb.ToString().TrimEnd();
        }
    }
}
