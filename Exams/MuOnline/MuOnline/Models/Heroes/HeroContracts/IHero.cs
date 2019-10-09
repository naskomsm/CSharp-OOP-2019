namespace MuOnline.Models.Heroes.HeroContracts
{
    using MuOnline.Models.Inventories.Contracts;

    public interface IHero
    {
        int Strength { get; }

        int Defense { get; }

        int Health { get; }

        int Energy { get; }

        IInventory Inventory { get; }

        bool IsAlive { get; }

        void TakeDamage(int damagePoints);

        int TotalAttackPoints { get; }

        int TotalHealthPoints { get; }

        int TotalDefensePoints { get; }

        int TotalEnergyPoints { get; }
    }
}
