namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomBoots : Item
    {
        private const int strengthPoints = 2;
        private const int agilityPoints = 1;
        private const int energyPoints = 2;
        private const int staminaPoints = 25;

        public DoomBoots()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
