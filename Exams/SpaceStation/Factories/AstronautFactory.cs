namespace SpaceStation.Factories
{
    using SpaceStation.Models.Astronauts;

    public class AstronautFactory
    {
        public Astronaut Create(string type, string astronautName)
        {
            Astronaut astronaut = null;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    break;
            }

            return astronaut;
        }
    }
}
