namespace SpaceStation.Models.Bags
{
    using System;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        public ICollection<string> Items { get; }
    }
}
