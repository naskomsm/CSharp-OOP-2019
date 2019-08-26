namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (input[0] == "AddAstronaut")
                    {

                    }
                    else if (input[0] == "AddPlanet")
                    {

                    }
                    else if (input[0] == "RetireAstronaut")
                    {

                    }
                    else if (input[0] == "ExplorePlanet")
                    {

                    }
                    else if (input[0] == "Report")
                    {

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
