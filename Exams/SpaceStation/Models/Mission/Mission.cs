namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public int DeadAstronauts { get; private set; }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    List<string> itemsOnPlanet = (List<string>)planet.Items;

                    for (int i = 0; i < itemsOnPlanet.Count; i++)
                    {
                        var currentItem = itemsOnPlanet[i];

                        astronaut.Breath();
                        astronaut.Bag.Items.Add(currentItem);
                        itemsOnPlanet.Remove(currentItem);

                        i--;
                        if (!astronaut.CanBreath)
                        {
                            DeadAstronauts++;
                            break;
                        }
                    }
                }
            }
        }
    }
}
