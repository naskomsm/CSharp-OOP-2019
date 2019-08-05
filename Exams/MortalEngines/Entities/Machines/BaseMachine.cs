namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defencePoints, double healthPoints)
        {
            this.Targets = new List<string>();
            this.pilot = null;

            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        } // ok

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        } // ok

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double pointsToSubstract = Math.Abs(this.AttackPoints - target.DefensePoints);
            target.HealthPoints -= pointsToSubstract;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");

            string extension = string.Join(",", this.Targets);
            if (!this.Targets.Any())
            {
                extension = "None";
            }

            sb.AppendLine($" *Targets: {extension}");

            return sb.ToString().TrimEnd();
        }
    }
}