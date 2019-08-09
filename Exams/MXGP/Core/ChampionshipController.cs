namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Factories;
    using MXGP.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionshipController : IChampionshipController
    {
        //Repos
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;

        //Factories
        private RiderFactory riderFactory;
        private MotorcycleFactory motorcycleFactory;
        private RaceFactory raceFactory;

        public ChampionshipController()
        {
            //Repos
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();

            //Factories
            this.riderFactory = new RiderFactory();
            this.motorcycleFactory = new MotorcycleFactory();
            this.raceFactory = new RaceFactory();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);
            var rider = this.riderRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);
            var rider = this.riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var searchedMotorcycle = this.motorcycleRepository.GetByName(model);

            if (searchedMotorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            var motorcycle = this.motorcycleFactory.Create(type, model, horsePower);
            this.motorcycleRepository.Add(motorcycle);

            return $"{type}Motorcycle {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var searchedRace = this.raceRepository.GetByName(name);

            if (searchedRace != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            var race = this.raceFactory.Create(name, laps);
            this.raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            var searchedRider = this.riderRepository.GetByName(riderName);

            if (searchedRider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            var rider = this.riderFactory.Create(riderName);
            this.riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if(race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var allRiders = this.riderRepository.GetAll()
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToList();

            this.raceRepository.Remove(race);

            var output = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                string place = string.Empty;
                if (i == 0) place = "first";
                else if (i == 1) place = "second";
                else if (i == 2) place = "third";

                output.Add($"Rider {allRiders[i].Name} is {place} in Loket race.");
            }

            return string.Join("\n", output);
        }
    }
}
