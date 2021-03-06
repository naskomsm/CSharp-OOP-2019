﻿namespace HotelReservation
{
    using HotelReservation.Enums;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            double pricePerDay = double.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);

            Season season = new Season();
            Discount discount = new Discount();

            string seasonType = input[2];
            switch (seasonType)
            {
                case "Summer":
                    season = (Season)4;
                    break;
                case "Winter":
                    season = (Season)3;
                    break;
                case "Autumn":
                    season = (Season)1;
                    break;
                case "Spring":
                    season = (Season)2;
                    break;
                default:
                    break;
            }

            if (input.Length == 3)
            {
                string discountType = input[3];
                switch (discountType)
                {
                    case "None":
                        break;
                    case "SecondVisit":
                        discount = (Discount)10;
                        break;
                    case "VIP":
                        discount = (Discount)20;
                        break;
                    default:
                        break;
                }
            }


            PriceCalculator calculator = new PriceCalculator();
            double finalPrice = calculator.CalculatePrice(pricePerDay, numberOfDays, season, discount);
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
