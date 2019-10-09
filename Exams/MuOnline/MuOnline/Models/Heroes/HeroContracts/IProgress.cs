namespace MuOnline.Models.Heroes.HeroContracts
{
    public interface IProgress
    {
        int Experience { get; }

        int Level { get; }

        void AddExperience(int experience);
    }
}
