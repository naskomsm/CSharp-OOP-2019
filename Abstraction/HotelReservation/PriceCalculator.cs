namespace HotelReservation
{

    public class PriceCalculator
    {
        public double CalculatePrice(double pricePerDay, int numberOfDays,Season season,Disctount disctount)
        {
            int multiplier = (int)season;
            double discountMultiplier = (double)disctount / 100;

            double priceBeforeDictount = numberOfDays * pricePerDay * multiplier;
            double discountAmount = priceBeforeDictount * discountMultiplier;
            double finalPrice = priceBeforeDictount - discountAmount;
            return finalPrice;
        }

        public double PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public enum Season
        {
            Autumn = 1,
            Sprint = 2,
            Winter = 3,
            Summer = 4
        }

        public enum Disctount
        {
            None,
            SecondVisit = 10,
            VIP = 20
        }
    }
}
