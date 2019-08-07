namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine()
                        .Split();

                    string command = input[0];

                    if(command == "End")
                    {
                        break;
                    }

                    switch (command)
                    {
                        case "CreateRider":
                            string name = input[1];
                            //todo
                            break;
                        case "CreateMotorcycle":
                            string motorcycleType = input[1];
                            string motorcycleModel = input[2];
                            int motorcycleHp = int.Parse(input[3]);
                            //todo
                            break;
                        case "AddMotorcycleToRider":
                            string riderName = input[1];
                            string motorcycleName = input[2];
                            //todo
                            break;
                        case "AddRiderToRace":
                            string raceName = input[1];
                            riderName = input[2];
                            //todo
                            break;
                        case "CreateRace":
                            raceName = input[1];
                            int laps = int.Parse(input[2]);
                            //todo
                            break;
                        case "StartRace":
                            raceName = input[1];
                            //todo
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.Message}");
                }
            }
        }
    }
}
