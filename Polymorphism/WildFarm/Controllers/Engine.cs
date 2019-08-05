namespace WildFarm.Controllers
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Factories;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Foods;

    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] animalArgs = input.Split();
                Animal animal = AnimalFactory.Create(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();
                Food food = FoodFactory.Create(foodArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
