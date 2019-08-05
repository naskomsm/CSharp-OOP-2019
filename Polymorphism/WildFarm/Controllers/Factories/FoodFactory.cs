namespace WildFarm.Factories
{
    using WildFarm.Models.Foods;

    public static class FoodFactory
    {
        public static Food Create(params string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            Food currentFood = null;

            if (foodType == nameof(Fruit))
            {
                currentFood = new Fruit(foodQuantity);
            }
            else if (foodType == nameof(Meat))
            {
                currentFood = new Meat(foodQuantity);
            }
            else if (foodType == nameof(Seeds))
            {
                currentFood = new Seeds(foodQuantity);
            }
            else if (foodType == nameof(Vegetable))
            {
                currentFood = new Vegetable(foodQuantity);
            }
            return currentFood;
        }
    }
}
