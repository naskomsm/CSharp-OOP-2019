namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Count > 0 && civilPlayers.Count > 0)
            {
                var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault();
                var currentCivilPlayer = civilPlayers.FirstOrDefault();

                mainPlayer.GunRepository.Remove(currentGun);
                civilPlayers.Remove(currentCivilPlayer);


            }
        }
    }
}
