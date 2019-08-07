namespace HotelReservation
{
    using HotelReservation.Enums;

    public class PriceCalculator
    {
        public double PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public double CalculatePrice(double pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            int multiplier = (int)season;
            double discountMultiplier = (double)discount / 100;

            double priceBeforeDictount = numberOfDays * pricePerDay * multiplier;
            double discountAmount = priceBeforeDictount * discountMultiplier;
            double finalPrice = priceBeforeDictount - discountAmount;
            return finalPrice;
        }
    }
}
