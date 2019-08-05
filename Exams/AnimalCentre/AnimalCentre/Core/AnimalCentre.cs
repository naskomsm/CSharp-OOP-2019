namespace AnimalCentre.Core
{
    using Factories;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Hotel;
    using global::AnimalCentre.Models.Proceedurs;
    using System.Collections.Generic;
    using System.Text;

    public class AnimalCentre
    {
        private Hotel hotel;
        private AnimalFactory animalFactory;
        private Dictionary<string, List<IAnimal>> proceduresAndItsAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.proceduresAndItsAnimals = new Dictionary<string, List<IAnimal>>()
            {
                ["Chip"] = new List<IAnimal>(),
                ["Vaccinate"] = new List<IAnimal>(),
                ["Fitness"] = new List<IAnimal>(),
                ["Play"] = new List<IAnimal>(),
                ["DentalCare"] = new List<IAnimal>(),
                ["NailTrim"] = new List<IAnimal>(),

            };
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var createdAnimal = this.animalFactory.Create(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(createdAnimal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            Chip chip = new Chip();

            var animal = this.hotel.Animals[name];

            chip.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["Chip"].Add(animal);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            Vaccinate vaccinate = new Vaccinate();

            var animal = this.hotel.Animals[name];

            vaccinate.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["Vaccinate"].Add(animal);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            Fitness fitness = new Fitness();

            var animal = this.hotel.Animals[name];

            fitness.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["Fitness"].Add(animal);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            Play play = new Play();

            var animal = this.hotel.Animals[name];

            play.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["Play"].Add(animal);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            DentalCare dentalCare = new DentalCare();

            var animal = this.hotel.Animals[name];

            dentalCare.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["DentalCare"].Add(animal);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            NailTrim nailTrim = new NailTrim();

            var animal = this.hotel.Animals[name];

            nailTrim.DoService(animal, procedureTime);

            this.proceduresAndItsAnimals["NailTrim"].Add(animal);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = this.hotel.Animals[animalName];
            animal.IsAdopt = true;

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return "{owner} adopted animal without chip";
            }
        }

        public string History(string type) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(type);
            foreach (var animal in proceduresAndItsAnimals)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
