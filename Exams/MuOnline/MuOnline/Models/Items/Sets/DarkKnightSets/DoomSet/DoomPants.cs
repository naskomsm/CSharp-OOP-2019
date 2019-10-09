namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomPants : Item
    {
        private const int strengthPoints = 2;
        private const int agilityPoints = 6;
        private const int energyPoints = 15;
        private const int staminaPoints = 5;

        public DoomPants()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
