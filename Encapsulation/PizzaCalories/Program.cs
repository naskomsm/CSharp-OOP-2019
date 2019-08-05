namespace PizzaCalories
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                string pizzaName = pizzaArgs[1];

                string[] doughArgs = Console.ReadLine().Split();
                string doughFlourType = doughArgs[1];
                string doughBakingTechnique = doughArgs[2];
                double weight = double.Parse(doughArgs[3]);
                Dough dough = new Dough(doughFlourType, doughBakingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] toppingArgs = input.Split();
                    string toppingType = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories().ToString("f2")} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
