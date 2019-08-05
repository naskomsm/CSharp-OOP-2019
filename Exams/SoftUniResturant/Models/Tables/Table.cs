namespace SoftUniResturant.Models.Tables
{
    using SoftUniResturant.Models.Drinks.Contracts;
    using SoftUniResturant.Models.Foods.Contracts;
    using SoftUniResturant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;

        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal PricePerPerson { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public int TableNumber { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.foodOrders.Sum(x => x.Price)
            + this.drinkOrders.Sum(x => x.Price)
            + PricePerPerson * numberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            string foodOrders = this.foodOrders.Count > 0 ? this.foodOrders.Count.ToString() : "None";
            sb.AppendLine($"Food orders: {foodOrders}");
            foreach (var food in this.foodOrders)
            {
                sb.AppendLine(food.ToString());
            }

            string drinkOrders = this.drinkOrders.Count > 0 ? this.drinkOrders.Count.ToString() : "None";
            sb.AppendLine($"Drink orders: {drinkOrders}");
            foreach (var drink in this.drinkOrders)
            {
                sb.AppendLine(drink.ToString());
            }


            return sb.ToString().TrimEnd();
        }
    }
}
