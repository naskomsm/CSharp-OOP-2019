namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private ChampionshipController controller;

        public Engine()
        {
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine()
                        .Split();

                    string command = input[0];

                    if (command == "End")
                    {
                        break;
                    }

                    string result = string.Empty;
                    switch (command)
                    {
                        case "CreateRider":
                            string name = input[1];
                            result = controller.CreateRider(name);
                            break;
                        case "CreateMotorcycle":
                            string motorcycleType = input[1];
                            string motorcycleModel = input[2];
                            int motorcycleHp = int.Parse(input[3]);
                            result = controller.CreateMotorcycle(motorcycleType, motorcycleModel, motorcycleHp);
                            break;
                        case "AddMotorcycleToRider":
                            string riderName = input[1];
                            string motorcycleName = input[2];
                            result = controller.AddMotorcycleToRider(riderName, motorcycleName);
                            break;
                        case "AddRiderToRace":
                            string raceName = input[1];
                            riderName = input[2];
                            result = controller.AddRiderToRace(raceName, riderName);
                            break;
                        case "CreateRace":
                            raceName = input[1];
                            int laps = int.Parse(input[2]);
                            result = controller.CreateRace(raceName, laps);
                            break;
                        case "StartRace":
                            raceName = input[1];
                            result = controller.StartRace(raceName);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
