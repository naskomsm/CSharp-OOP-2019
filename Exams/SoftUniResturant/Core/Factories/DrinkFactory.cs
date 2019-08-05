namespace SoftUniResturant.Core.Factories
{
    using SoftUniResturant.Models.Drinks;
    using SoftUniResturant.Models.Drinks.Contracts;

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            if (type == "Alcohol")
            {
                return new Alcohol(name, servingSize, brand);
            }
            else if (type == "FuzzyDrink")
            {
                return new FuzzyDrink(name, servingSize, brand);
            }
            else if (type == "Juice")
            {
                return new Juice(name, servingSize, brand);
            }
            else if (type == "Water")
            {
                return new Water(name, servingSize, brand);
            }

            return null;
        }
    }
}
