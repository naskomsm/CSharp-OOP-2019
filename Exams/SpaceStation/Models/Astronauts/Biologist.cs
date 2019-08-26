﻿namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double initialOxygen = 70;

        public Biologist(string name)
            : base(name, initialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;
        }
    }
}
