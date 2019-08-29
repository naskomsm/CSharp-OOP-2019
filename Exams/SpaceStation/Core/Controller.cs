namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Factories;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private AstronautFactory astronautFactory;

        private PlanetRepository planetRepository;
        private List<IPlanet> planetsExplored;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.astronautFactory = new AstronautFactory();

            this.planetRepository = new PlanetRepository();
            this.planetsExplored = new List<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = astronautFactory.Create(type, astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            this.astronautRepository.Add(astronaut);


            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            if (items != null)
            {
                foreach (var item in items)
                {
                    planet.Items.Add(item);
                }

            }

            this.planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsToSend = new List<IAstronaut>();

            foreach (var astronaut in this.astronautRepository.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astronautsToSend.Add(astronaut);
                }
            }

            if (astronautsToSend.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            var planet = this.planetRepository.FindByName(planetName);
            var mission = new Mission();

            mission.Explore(planet, astronautsToSend);
            this.planetsExplored.Add(planet);

            return $"Planet: {planetName} was explored! Exploration finished with {mission.DeadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.planetsExplored.Count} planets were explored!");
            sb.AppendLine($"Astronauts info: ");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }

                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronautToRemove = this.astronautRepository.FindByName(astronautName);

            if (astronautToRemove == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astronautRepository.Remove(astronautToRemove);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
