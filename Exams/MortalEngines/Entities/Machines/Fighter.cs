namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defencePoints)
            : base(name, attackPoints, defencePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
            this.AttackPoints += 50;
            this.DefensePoints -= 25;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }

            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string output = base.ToString();

            sb.AppendLine(output);

            string extension;
            if (this.AggressiveMode == true) extension = "ON";
            else extension = "OFF";

            sb.AppendLine($" *Aggressive: {extension}");

            return sb.ToString().TrimEnd();
        }
    }
}