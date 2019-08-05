namespace Vehicles
{
    using global::Vehicles.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run(List<Vehicle> vehicles)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                string vehicle = commandArgs[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);

                    if (vehicle == "Car")
                    {
                        Car car = (Car)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Car));
                        car.Drive(distance);
                    }
                    else if (vehicle == "Truck")
                    {
                        Truck truck = (Truck)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Truck));
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (vehicle == "Bus")
                    {
                        Bus bus = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Bus));
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    Bus bus = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Bus));
                    double distance = double.Parse(commandArgs[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicle == "Car")
                        {
                            Car car = (Car)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Car));
                            double fuel = double.Parse(commandArgs[2]);
                            car.Refuel(fuel);
                        }
                        else if (vehicle == "Truck")
                        {
                            Truck truck = (Truck)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Truck));
                            double fuel = double.Parse(commandArgs[2]);
                            truck.Refuel(fuel);
                        }
                        else if (vehicle == "Bus")
                        {
                            Bus bus = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == nameof(Bus));
                            double fuel = double.Parse(commandArgs[2]);
                            bus.Refuel(fuel);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }


            foreach (var vehice in vehicles)
            {
                Console.WriteLine(vehice);
            }

        }
    }
}
