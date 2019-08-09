namespace MXGP.Models.Factories
{
    using MXGP.Models.Factories.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleFactory : IMotorcycleFactory
    {
        public IMotorcycle Create(string type,string model, int horsePower)
        {
            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "PowerMotorcycle":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
                case "SpeedMotorcycle":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                default:
                    break;
            }

            return motorcycle;
        }
    }
}
