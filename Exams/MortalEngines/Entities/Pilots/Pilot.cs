namespace MortalEngines.Entities.Pilots
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string name;

        public Pilot(string name)
        {
            this.Machines = new List<IMachine>();
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public List<IMachine> Machines { get; }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.Machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in this.Machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}