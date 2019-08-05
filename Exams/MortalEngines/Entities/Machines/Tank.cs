namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, attackPoints, defencePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
            this.AttackPoints -= 40;
            this.DefensePoints += 30;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }

            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string output = base.ToString();

            sb.AppendLine(output);

            string extension;
            if (this.DefenseMode == true) extension = "ON";
            else extension = "OFF";

            sb.AppendLine($" *Defense: {extension}");

            return sb.ToString().TrimEnd();
        }
    }
}