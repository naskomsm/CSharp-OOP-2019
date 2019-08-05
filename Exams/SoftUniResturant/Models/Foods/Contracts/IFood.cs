namespace SoftUniResturant.Models.Foods.Contracts
{
    public interface IFood
    {
        string Name { get; }

        int ServingSize { get; }

        decimal Price { get; }
    }
}
