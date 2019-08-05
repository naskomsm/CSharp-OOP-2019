namespace Shapes
{
    using Shapes.ChildrenClasses;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(5,6);
            Console.WriteLine("Rectangle:");
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine();
            rectangle.Draw();

            Console.WriteLine();

            Shape circle = new Circle(7);
            Console.WriteLine("Circle:");
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine();
            circle.Draw();
        }
    }
}
