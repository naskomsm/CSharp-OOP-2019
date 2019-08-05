namespace Mordor_sCruelPlan
{
    using Mordor_sCruelPlan.Foods;
    using Mordor_sCruelPlan.Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodsEaten = new List<Food>();
            FoodFactory foodFactory = new FoodFactory();

            string[] foods = Console.ReadLine().Split();

            foreach (var food in foods)
            {
                Food foodToAdd = foodFactory.GetFood(food);
                foodsEaten.Add(foodToAdd);
            }

            int hapinessFood = foodsEaten.Select(x => x == null ? -1 : x.Happiness).Sum();

            Console.WriteLine(hapinessFood);

            if (hapinessFood < -5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if (hapinessFood >= 1 && hapinessFood <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else if (hapinessFood >= -5 && hapinessFood <= 0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (hapinessFood > 15)
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }

    }
}

