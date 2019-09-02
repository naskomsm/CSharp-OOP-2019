namespace ViceCity.Core
{
    using ViceCity.Core.Contracts;
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
                    if (input[0] == "AddPlayer")
                    {
                        var username = input[1];

                        output = controller.AddPlayer(username);
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        output = controller.AddGun(type, name);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var username = input[1];

                        output = controller.AddGunToPlayer(username);
                    }
                    else if (input[0] == "Fight")
                    {
                        output = controller.Fight();
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
