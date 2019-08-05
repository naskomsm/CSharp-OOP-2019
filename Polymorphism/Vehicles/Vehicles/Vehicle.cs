namespace Vehicles
{
    using System;

    public class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public int TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public virtual string Drive(double distance)
        {
            string vehicleName = this.GetType().Name;
            double neededFuel = distance * FuelConsumption;

            if (neededFuel > FuelQuantity)
            {
                return $"{vehicleName} needs refueling";
            }
            this.FuelQuantity -= neededFuel;
            return $"{vehicleName} travelled {distance} km";
        }

        public virtual void Refuel(double quantity)
        {
            double totalFuelAmount = this.FuelQuantity + quantity;

            if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (totalFuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            this.FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
