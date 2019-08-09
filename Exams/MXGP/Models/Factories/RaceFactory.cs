namespace MXGP.Models.Factories
{
    using MXGP.Models.Factories.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;

    public class RaceFactory : IRaceFactory
    {
        public Race Create(string name, int laps)
        {
            return new Race(name, laps);
        }
    }
}
