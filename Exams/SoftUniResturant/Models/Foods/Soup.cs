﻿namespace SoftUniResturant.Models.Foods
{
    public class Soup : Food
    {
        private const int InitialServingSize = 245;

        public Soup(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }
    }
}
