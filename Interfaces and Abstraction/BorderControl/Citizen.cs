namespace BorderControl
{
    public class Citizen : IObject
    {
        public Citizen(string name, string id, int age,string birthday)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.Birthday = birthday;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public int Age { get; private set; }

        public string Birthday { get; private set; }
    }
}
