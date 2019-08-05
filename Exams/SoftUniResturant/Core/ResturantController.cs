namespace SoftUniResturant.Core
{
    using SoftUniResturant.Core.Factories;
    using SoftUniResturant.Models.Drinks.Contracts;
    using SoftUniResturant.Models.Foods.Contracts;
    using SoftUniResturant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ResturantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        private decimal income = 0;

        public ResturantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = this.foodFactory.CreateFood(type, name, price);
            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var notReservedTable = this.tables.FirstOrDefault(x => x.IsReserved == false);

            if (notReservedTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            notReservedTable.Reserve(numberOfPeople);

            return $"Table {notReservedTable.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.menu.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var tableBill = table.GetBill();
            this.income += tableBill;

            table.Clear();

            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {tableBill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
