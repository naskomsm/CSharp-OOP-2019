namespace Shapes.ChildrenClasses
{
    using System;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            double area = height * width;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (width + height);
            return perimeter;
        }

        public override void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 0; i < this.height - 1; i++)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', ' ');
        }

        private void DrawLine(double width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
