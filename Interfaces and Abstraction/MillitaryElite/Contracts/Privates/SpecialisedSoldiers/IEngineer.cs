namespace MillitaryElite.Contracts.Privates.SpecialisedSoldiers
{
    using MillitaryElite.Models.Privates.SpecializedSoldiers;
    using System.Collections.Generic;

    public interface IEngineer
    {
        HashSet<Repair> Repairs { get; }
    }
}
