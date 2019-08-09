namespace MXGP.Models.Factories.Contracts
{
    using MXGP.Models.Races;

    public interface IRaceFactory
    {
        Race Create(string name, int laps);
    }
}
