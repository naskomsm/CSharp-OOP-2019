namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int initialLifePoints = 100;

        public MainPlayer(string name)
            : base(name, initialLifePoints)
        {
        }
    }
}
