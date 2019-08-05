namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft,Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Point topLeft { get; set; }

        public Point bottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.topLeft.x <= point.x && this.bottomRight.x >= point.x;
            bool isInVertical = this.topLeft.y <= point.y && this.bottomRight.y >= point.y;

            bool isInRectangle = isInHorizontal && isInVertical;
            return isInRectangle;
        }


    }
}
