namespace MXGP.Models.Factories.Contracts
{
    using MXGP.Models.Motorcycles.Contracts;

    public interface IMotorcycleFactory
    {
        IMotorcycle Create(string type,string model, int horsePower);
    }
}
