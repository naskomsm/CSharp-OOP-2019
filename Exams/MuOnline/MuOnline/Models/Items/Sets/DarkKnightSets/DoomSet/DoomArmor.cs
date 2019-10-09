namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomArmor : Item
    {
        private const int strengthPoints = 12;
        private const int agilityPoints = 25;
        private const int energyPoints = 15;
        private const int staminaPoints = 70;

        public DoomArmor() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
