namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private Controller controller;

        public Engine()
        {
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                var output = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var astronautType = input[1];
                        var astronautName = input[2];

                        output = this.controller.AddAstronaut(astronautType, astronautName);
                    }

                    else if (input[0] == "AddPlanet")
                    {
                        var planetName = input[1];

                        if (input.Length == 2)
                        {
                            output = this.controller.AddPlanet(planetName, null);
                        }

                        else
                        {
                            var items = new string[input.Length - 2];

                            for (int i = 2; i < input.Length; i++)
                            {
                                items[i - 2] = input[i];
                            }

                            output = this.controller.AddPlanet(planetName, items);
                        }
                    }

                    else if (input[0] == "RetireAstronaut")
                    {
                        var astronautName = input[1];

                        output = this.controller.RetireAstronaut(astronautName);
                    }

                    else if (input[0] == "ExplorePlanet")
                    {
                        var planetName = input[1];

                        output = this.controller.ExplorePlanet(planetName);
                    }

                    else if (input[0] == "Report")
                    {
                        output = this.controller.Report();
                    }

                    Console.WriteLine(output);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
