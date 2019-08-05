namespace SoftUniResturant.Core.Factories
{
    using SoftUniResturant.Models.Foods;
    using SoftUniResturant.Models.Foods.Contracts;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            if (type == "Dessert")
            {
                return new Dessert(name, price);
            }
            else if (type == "Salad")
            {
                return new Salad(name, price);
            }
            else if (type == "Soup")
            {
                return new Soup(name, price);
            }
            else if (type == "MainCourse")
            {
                return new MainCourse(name, price);
            }

            return null;
        }
    }
}
