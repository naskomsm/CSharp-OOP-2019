namespace Vehicles
{
    using global::Vehicles.Vehicles;
    using System;
    using System.Collections.Generic;

    public class CarFactory
    {
        public void Run(List<Vehicle> vehicles)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleArgs = Console.ReadLine().Split();

                string vehicleType = vehicleArgs[0];

                double fuelQuantity = double.Parse(vehicleArgs[1]);
                double fuelConsumption = double.Parse(vehicleArgs[2]);
                int tankCapacity = int.Parse(vehicleArgs[3]);

                Vehicle vehicle = null;
                if (i == 0)
                {
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (i == 1)
                {
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (i == 2)
                {
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                }

                vehicles.Add(vehicle);
            }
        }
    }
}
