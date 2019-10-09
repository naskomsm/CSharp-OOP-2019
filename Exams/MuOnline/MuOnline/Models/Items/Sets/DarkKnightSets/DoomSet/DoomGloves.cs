namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomGloves : Item
    {
        private const int strengthPoints = 6;
        private const int agilityPoints = 3;
        private const int staminaPoints = 2;
        private const int energyPoints = 4;

        public DoomGloves() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
