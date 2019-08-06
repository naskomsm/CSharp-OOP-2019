namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private ManagerController controller;

        public Engine()
        {
            this.controller = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    break;
                }

                var command = input[0];

                var result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            var playerType = input[1];
                            var playerUsername = input[2];

                            result = controller.AddPlayer(playerType, playerUsername);
                            break;
                        case "AddCard":
                            var cardType = input[1];
                            var cardName = input[2];

                            result = controller.AddCard(cardType, cardName);
                            break;
                        case "AddPlayerCard":
                            var username = input[1];
                            cardName = input[2];

                            result = controller.AddPlayerCard(username, cardName);
                            break;
                        case "Fight":
                            var attackUser = input[1];
                            var enemyUser = input[2];

                            result = controller.Fight(attackUser, enemyUser);
                            break;
                        case "Report":
                            result = controller.Report();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
