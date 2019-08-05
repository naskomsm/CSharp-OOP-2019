using MillitaryElite.Models.Privates.SpecializedSoldiers;
using System.Collections.Generic;

namespace MillitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    public interface ICommando
    {
        HashSet<Mission> Missions { get; }

        void CompleteMission(string codeName);
    }
}
