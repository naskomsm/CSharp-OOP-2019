namespace MySolidDemo.Layouts.Types
{
    using MySolidDemo.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
