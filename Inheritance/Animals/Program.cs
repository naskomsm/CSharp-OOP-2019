namespace Animals
{
    using Animals.Contracts;
    using Animals.Factory;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var animals = GetAnimals();
            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }

        private static Queue<Animal> GetAnimals()
        {
            var animals = new Queue<Animal>();

            while (true)
            {
                var kind = Console.ReadLine();
                if (kind == "Beast!")
                {
                    break;
                }


                var animalDetails = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = animalDetails[0];
                var age = int.Parse(animalDetails[1]);
                var gender = animalDetails[2];

                try
                {
                    var animal = AnimalFactory.GetAnimal(kind, name, age, gender);
                    animals.Enqueue(animal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            return animals;
        }
    }
}
