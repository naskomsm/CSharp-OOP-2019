namespace MuOnline.Models.Heroes
{
    using System;
    using System.Linq;

    using HeroContracts;
    using Inventories;
    using Inventories.Contracts;

    public abstract class Hero : IHero, IIdentifiable, IProgress
    {
        // identifying
        private string username;

        // stats
        private int strength;
        private int defense;
        private int health;
        private int energy;
        private int totalEnergyPoints;

        // leveling
        private int experience;
        private int level;

        protected Hero(string username, int strength, int defense, int stamina, int energy)
        {
            // identifying
            this.Username = username;

            // stats
            this.Strength = strength;
            this.Defense = defense;
            this.Health = stamina;
            this.Energy = energy;

            // leveling
            this.Experience = 0;
            this.Level = 0;

            this.Inventory = new Inventory();

            this.TotalHealthPoints = GetTotalHealthPoints();
            this.TotalDefensePoints = GetTotalAgilityPoints();
        }

        public IInventory Inventory { get; }

        public bool IsAlive
            => this.TotalHealthPoints > 0;

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (value == null || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null!");
                }

                this.username = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Strength cannot be less than zero!");
                }

                this.strength = value;
            }
        }

        public int Defense
        {
            get
            {
                return this.defense;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Agility cannot be less than zero!");
                }

                this.defense = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Health cannot be less than zero!");
                }

                this.health = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Energy cannot be less than zero!");
                }

                this.energy = value;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Experience cannot be less than zero!");
                }

                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Levels cannot be less than zero!");
                }

                this.level = value;
            }
        }


        public void TakeDamage(int damagePoints)
        {
            if (this.TotalDefensePoints > 0)
            {
                this.TotalDefensePoints -= damagePoints;
            }
            else
            {
                this.TotalHealthPoints -= damagePoints;
            }
        }

        public void AddExperience(int experience)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }

            this.Experience += experience;

            if (this.Experience >= 9000)
            {
                AddLevel();
            }

            if (this.Level >= 120)
            {
                AddReset();
            }
        }

        private void AddReset()
        {
            this.Level = 0;
        }

        private void AddLevel()
        {
            this.Level++;

            if (this.Level == 120)
            {
                throw new ArgumentException("You have reached max level!");
            }
        }

        public int TotalAttackPoints
            => this.Strength +
               this.Defense * 10 / 100 +
               this.Energy * 5 / 100 +
               this.Inventory.Items.Sum(x => x.Strength);
        
        public int TotalEnergyPoints
            => this.Energy +
               this.Inventory.Items.Sum(x => x.Energy);

        public int TotalDefensePoints { get; private set; }

        public int TotalHealthPoints { get; private set; }

        private int GetTotalHealthPoints()
        {
            return this.Health + this.Inventory.Items.Sum(x => x.Stamina);
        }

        private int GetTotalAgilityPoints()
        {
            return this.Defense + this.Inventory.Items.Sum(x => x.Agility);
        }
    }
}
