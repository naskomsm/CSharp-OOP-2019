namespace MXGP.Models.Factories
{
    using MXGP.Models.Factories.Contracts;
    using MXGP.Models.Riders;

    public class RiderFactory : IRiderFactory
    {
        public Rider Create(string name)
        {
            return new Rider(name);
        }
    }
}
