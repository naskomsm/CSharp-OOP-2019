namespace Shapes
{
    using System;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get => this.width;
            private set
            {
                CoordinateValidator(value);
                this.width = value;
            }
        }

        public int Height
        {
            get => this.height;
            private set
            {
                CoordinateValidator(value);
                this.height = value;
            }
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 0; i < this.Height - 1; i++)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', ' ');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < Width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);

        }

        private void CoordinateValidator(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid coordinate");
            }
        }
    }
}
