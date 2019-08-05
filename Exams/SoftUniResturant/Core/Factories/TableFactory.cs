namespace SoftUniResturant.Core.Factories
{
    using SoftUniResturant.Models.Tables;
    using SoftUniResturant.Models.Tables.Contracts;

    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            if (type == "Inside")
            {
                return new InsideTable(tableNumber, capacity);
            }
            else if (type == "Outside")
            {
                return new OutsideTable(tableNumber, capacity);
            }

            return null;
        }
    }
}
