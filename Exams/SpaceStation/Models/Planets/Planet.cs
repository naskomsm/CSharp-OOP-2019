namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
        }

        public ICollection<string> Items { get; }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                this.name = value;
            }
        }
    }
}
