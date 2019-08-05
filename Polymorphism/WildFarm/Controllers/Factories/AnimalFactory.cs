namespace WildFarm.Models.Animals
{
    using WildFarm.Models.Animals.Birds;
    using WildFarm.Models.Animals.Mammals;
    using WildFarm.Models.Animals.Mammals.Felines;

    public static class AnimalFactory
    {
        public static Animal Create(params string[] animalArgs)
        {
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            Animal currentAnimal = null;

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalArgs[3]);
                currentAnimal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalArgs[3]);
                currentAnimal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalArgs[3];
                currentAnimal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalArgs[3];
                currentAnimal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];
                currentAnimal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];
                currentAnimal = new Tiger(name, weight, livingRegion, breed);
            }
            return currentAnimal;
        }
    }
}
