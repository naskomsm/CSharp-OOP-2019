namespace SoftUniResturant.Core
{
    using System;

    public class Engine
    {
        private ResturantController controller;

        public Engine()
        {
            this.controller = new ResturantController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    Console.WriteLine(this.controller.GetSummary());
                    break;
                }

                string command = input[0];

                string result = "";

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = input[1];
                            string name = input[2];
                            decimal price = decimal.Parse(input[3]);

                            result = this.controller.AddFood(type, name, price);
                            break;
                        case "AddDrink":
                            type = input[1];
                            name = input[2];
                            int servingSize = int.Parse(input[3]);
                            string brand = input[4];

                            result = this.controller.AddDrink(type, name, servingSize, brand);
                            break;
                        case "AddTable":
                            type = input[1];
                            int tableNumber = int.Parse(input[2]);
                            int capacity = int.Parse(input[3]);

                            result = this.controller.AddTable(type, tableNumber, capacity);
                            break;
                        case "ReserveTable":
                            int numberOfPeople = int.Parse(input[1]);

                            result = this.controller.ReserveTable(numberOfPeople);
                            break;
                        case "OrderFood":
                            tableNumber = int.Parse(input[1]);
                            string foodName = input[2];

                            result = this.controller.OrderFood(tableNumber, foodName);
                            break;
                        case "OrderDrink":
                            tableNumber = int.Parse(input[1]);
                            string drinkName = input[2];
                            string drinkBrand = input[3];

                            result = this.controller.OrderDrink(tableNumber, drinkName, drinkBrand);
                            break;
                        case "LeaveTable":
                            tableNumber = int.Parse(input[1]);

                            result = this.controller.LeaveTable(tableNumber);
                            break;
                        case "GetFreeTablesInfo":
                            result = this.controller.GetFreeTablesInfo();
                            break;
                        case "GetOccupiedTablesInfo":
                            result = this.controller.GetOccupiedTablesInfo();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
