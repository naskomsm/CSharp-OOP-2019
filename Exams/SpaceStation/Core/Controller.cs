namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Factories;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using System;
    using System.Collections.Generic;

    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private AstronautFactory astronautFactory;

        private PlanetRepository planetRepository;


        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.astronautFactory = new AstronautFactory();

            this.planetRepository = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = astronautFactory.Create(type, astronautName);
            this.astronautRepository.Add(astronaut);

            if (astronaut == null)
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsToSend = new List<Astronaut>();

            foreach (var astronaut in this.astronautRepository.Models)
            {
                if(astronaut.Oxygen > 60)
                {
                    astronautsToSend.Add((Astronaut)astronaut);
                }
            }

            if(astronautsToSend.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            //todo
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronautToRemove = this.astronautRepository.FindByName(astronautName);

            if (astronautToRemove == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepository.Remove(astronautToRemove);
            return "Astronaut {astronautName} was retired!";
        }
    }
}
