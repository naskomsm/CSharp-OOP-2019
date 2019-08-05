namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<IObject> objects = new List<IObject>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            ObjectFactory factory = new ObjectFactory();
            factory.Run(numberOfPeople, objects);

            GetTotalFood(objects);
        }

        public static void GetTotalFood(List<IObject> objects)
        {
            int totalFoodBought = 0;
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                IBuyer buyer = (IBuyer)objects.FirstOrDefault(x => x.Name == name);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            foreach (var item in objects)
            {
                IBuyer buyer = (IBuyer)item;
                totalFoodBought += buyer.Food;
            }
            Console.WriteLine(totalFoodBought);
        }
    }
}
