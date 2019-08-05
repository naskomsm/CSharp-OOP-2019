namespace Animals
{
    using System;

    public abstract class Animal
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;
        
        public Animal(string name,int age,string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return string.Format("{0}{1}{2} {3} {4}{1}{5}",
                this.GetType().Name, // 0
                Environment.NewLine, // 1
                this.name, // 2
                this.age,  // 3
                this.gender, // 4
                this.ProduceSound()); // 5
        }
    }
}
