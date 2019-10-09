namespace MuOnline.Models.Inventories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Items.Contracts;

    public class Inventory : IInventory
    {
        private List<IItem> items;

        public Inventory()
        {
            this.items = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Items
            => this.items.AsReadOnly();

        public void AddItem(IItem item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            this.items.Add(item);
        }

        public string RemoveItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            if (this.items.Contains(item))
            {
                throw new InvalidOperationException("No such item in inventory");
            }

            this.items.Remove(item);

            return $"Removed {item.GetType().Name} from inventory!";
        }

        public IItem GetItem(string item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            var targetItem = this.items.FirstOrDefault(x => x.GetType().Name.ToLower() == item);

            if (targetItem == null)
            {
                throw new InvalidOperationException("No such item in inventory");
            }

            return targetItem;
        }
    }
}
