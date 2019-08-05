namespace Vehicles
{
    using global::Vehicles.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> vehicles = new List<Vehicle>();
            CarFactory factory = new CarFactory();
            factory.Run(vehicles);

            Engine engine = new Engine();
            engine.Run(vehicles);
        }
    }
}

