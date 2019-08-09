namespace MXGP.Models.Motorcycles
{
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private const int InitialCubicCentimeters = 125;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialCubicCentimeters)
        {
            if (horsePower < 50 || horsePower > 69)
            {
                throw new ArgumentException($"Invalid horse power: {horsePower}");
            }
        }
    }
}