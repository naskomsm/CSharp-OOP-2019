namespace AnimalCentre.Models.Hotel
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
            => this.animals.ToImmutableDictionary();
        
        public void Accommodate(IAnimal animal) // add method
        {
            if(this.animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner) // remove method
        {
            if (!this.animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animal = this.animals.FirstOrDefault(x => x.Key == animalName).Value;

            animal.Owner = owner;
            animal.IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}
