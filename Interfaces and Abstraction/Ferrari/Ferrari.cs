namespace Ferrari
{
    public class Ferrari : IFerrari, IDesribable
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => "488-Sprider";

        public string Driver { get; private set; }

        public string Describe()
        {
            return $"{Model}/{UseBrakes()}/{PushGasPedal()}/{this.Driver}";
        }

        public string PushGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
