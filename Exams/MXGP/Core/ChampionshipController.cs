namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.Models.Factories;
    using MXGP.Repositories;
    using System;

    public class ChampionshipController : IChampionshipController
    {
        //Repos
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;

        //Factories
        private RiderFactory riderFactory;
        private MotorcycleFactory motorcycleFactory;

        public ChampionshipController()
        {
            //Repos
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();

            //Factories
            this.riderFactory = new RiderFactory();
            this.motorcycleFactory = new MotorcycleFactory();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            throw new NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new NotImplementedException();
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

            return $"{type} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
