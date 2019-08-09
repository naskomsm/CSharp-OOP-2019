namespace MXGP.Models.Factories.Contracts
{
    using MXGP.Models.Riders;

    public interface IRiderFactory
    {
        Rider Create(string name);
    }
}
