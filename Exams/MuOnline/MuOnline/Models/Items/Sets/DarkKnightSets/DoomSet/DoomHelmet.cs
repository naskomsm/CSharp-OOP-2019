namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomHelmet : Item
    {
        private const int strengthPoints = 2;
        private const int agilityPoints = 5;
        private const int energyPoints = 6;
        private const int staminaPoints = 12;

        public DoomHelmet() 
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
