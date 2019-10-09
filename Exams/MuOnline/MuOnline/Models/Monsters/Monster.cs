namespace MuOnline.Models.Monsters
{
    using System;
    using Contracts;

    public abstract class Monster : IMonster
    {
        private int vitalityPoints;

        protected Monster(int attackPoints, int vitalityPoints)
        {
            this.AttackPoints = attackPoints;
            this.VitalityPoints = vitalityPoints;
        }

        public int AttackPoints { get; }

        public int VitalityPoints
        {
            get => this.vitalityPoints;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Vitality cant be zero or less!");
                }

                this.vitalityPoints = value;
            }
        }

        public bool IsAlive
            => this.VitalityPoints >= 0;

        public int TakeDamage(int attackPoints)
        {
            if (!this.IsAlive)
            {
                return 0;
            }

            var exp = Math.Abs(this.VitalityPoints - attackPoints);
            this.vitalityPoints -= attackPoints;

            return exp;
        }
    }
}
