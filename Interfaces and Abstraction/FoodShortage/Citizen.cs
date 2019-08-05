namespace FoodShortage
{
    public class Citizen : IObject, IBuyer
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.id = id;
            this.birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
