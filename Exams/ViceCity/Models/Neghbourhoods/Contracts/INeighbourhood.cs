namespace ViceCity.Models.Neghbourhoods.Contracts
{
    using ViceCity.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INeighbourhood
    {
        void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers);
    }
}
