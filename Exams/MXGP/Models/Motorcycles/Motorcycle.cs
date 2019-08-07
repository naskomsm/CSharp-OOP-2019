namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using System;

    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;

        protected Motorcycle(string model,int horsePower,double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (isValidHp(this.Model, value))
                {
                    this.horsePower = value;
                }
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / (this.HorsePower * laps);
        }

        private bool isValidHp(string model,int hp)
        {
            switch (model)
            {
                case "PowerMotorcycle":
                    if(hp < 70 || hp > 100)
                    {
                        throw new ArgumentException($"Invalid horse power: {hp}");
                    }
                    break;
                case "SpeedMotorcycle":
                    if (hp < 50 || hp > 69)
                    {
                        throw new ArgumentException($"Invalid horse power: {hp}");
                    }
                    break;
                default:
                    break;
            }

            return true;
        }
    }
}
