namespace SoftUniResturant.Models.Tables.Contracts
{
    using SoftUniResturant.Models.Drinks.Contracts;
    using SoftUniResturant.Models.Foods.Contracts;

    public interface ITable
    {
        int TableNumber { get; }

        int Capacity { get; }

        bool IsReserved { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();
    }
}
