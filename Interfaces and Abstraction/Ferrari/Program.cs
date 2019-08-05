namespace Ferrari
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            var car = new Ferrari(driver);
            Console.WriteLine(car.Describe());
        }
    }
}
