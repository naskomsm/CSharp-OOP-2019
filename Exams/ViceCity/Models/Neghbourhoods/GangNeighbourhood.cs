namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public int CivilsKilled { get; private set; }

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                if (mainPlayer.GunRepository.Models.Count == 0 || civilPlayers.Count == 0)
                {
                    break;
                }

                var gun = mainPlayer.GunRepository.Models.FirstOrDefault();
                var civil = civilPlayers.FirstOrDefault();

                while (civil.IsAlive)
                {
                    var damage = gun.Fire();
                    civil.TakeLifePoints(damage);

                    if (damage == 0)
                    {
                        mainPlayer.GunRepository.Remove(gun);
                        break;
                    }
                }

                if (civil.IsAlive == false)
                {
                    civilPlayers.Remove(civil);
                    CivilsKilled++;
                }
            }

            if (civilPlayers.Any())
            {
                while (true)
                {
                    if (mainPlayer.IsAlive == false)
                    {
                        break;
                    }

                    var currentCivil = civilPlayers.FirstOrDefault();
                    var gun = currentCivil.GunRepository.Models.FirstOrDefault();

                    if(gun == null)
                    {
                        break;
                    }

                    var damage = gun.Fire();
                    mainPlayer.TakeLifePoints(damage);

                    if(damage == 0)
                    {
                        currentCivil.GunRepository.Remove(gun);
                        continue;
                    }

                    if(currentCivil.GunRepository.Models.Count == 0)
                    {
                        civilPlayers.Remove(currentCivil);
                        continue;
                    }
                }
            }
        }
    }
}
