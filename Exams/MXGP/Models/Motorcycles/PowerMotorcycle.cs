namespace MXGP.Models.Motorcycles
{
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const int InitialCubicCentimeters = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
            if (horsePower < 70 || horsePower > 100)
            {
                throw new ArgumentException($"Invalid horse power: {horsePower}");
            }
        }
    }
}
