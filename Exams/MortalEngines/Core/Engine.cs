namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private MachinesManager manager;

        public Engine()
        {
            this.manager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Quit")
                {
                    break;
                }

                string command = input[0];

                string result = "";
                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            string name = input[1];
                            result = manager.HirePilot(name);
                            break;
                        case "ManufactureTank":
                            name = input[1];
                            double attack = double.Parse(input[2]);
                            double defense = double.Parse(input[3]);
                            result = manager.ManufactureTank(name, attack, defense);
                            break;
                        case "ManufactureFighter":
                            name = input[1];
                            attack = double.Parse(input[2]);
                            defense = double.Parse(input[3]);
                            result = manager.ManufactureFighter(name, attack, defense);
                            break;
                        case "Engage":
                            name = input[1];
                            string machineName = input[2];
                            result = manager.EngageMachine(name, machineName);
                            break;
                        case "Attack":
                            name = input[1];
                            machineName = input[2];
                            result = manager.AttackMachines(name, machineName);
                            break;
                        case "PilotReport":
                            name = input[1];
                            result = manager.PilotReport(name);
                            break;
                        case "MachineReport":
                            name = input[1];
                            result = manager.MachineReport(name);
                            break;
                        case "AggressiveMode":
                            name = input[1];
                            result = manager.ToggleFighterAggressiveMode(name);
                            break;
                        case "DefenseMode":
                            name = input[1];
                            result = manager.ToggleTankDefenseMode(name);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.InnerException.Message}");
                }
            }
        }
    }
}
