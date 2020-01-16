namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            var coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rectangle = new Rectangle(coordinates);
            var numberOfPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPoints; i++)
            {
                var pointCoordinates = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Point point = new Point(pointCoordinates);
                rectangle.Contains(point);
            }
            
        }
    }
}
