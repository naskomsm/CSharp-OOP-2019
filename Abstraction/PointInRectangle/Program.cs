namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int x1 = coordinates[0];
            int y1 = coordinates[1];

            int x2 = coordinates[2];
            int y2 = coordinates[3];

            Point topLeft = new Point(x1, y1);
            Point bottomRight = new Point(x2, y2);

            Rectangle rectangle = new Rectangle(topLeft,bottomRight);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] currentCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point currentPoint = new Point(currentCoordinates[0], currentCoordinates[1]);
                Console.WriteLine(rectangle.Contains(currentPoint));


            }
        }
    }
}
