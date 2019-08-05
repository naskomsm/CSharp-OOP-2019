namespace Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double airConditionConsumptuon = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionConsumptuon, tankCapacity)
        {
        }

        public override void Refuel(double quantity)
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
            else
            {
                FuelQuantity += (quantity * 0.95);
            }
        }
    }
}
