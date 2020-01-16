namespace PointInRectangle
{
    using System;

    public class Rectangle
    {
        public Rectangle(int[] coordinates)
        {
            TopLeft = new[] {coordinates[0], coordinates[1]};
            BottomRight = new []{coordinates[2], coordinates[3]};
        }

        public int[] TopLeft { get; set; }

        public int[] BottomRight { get; set; }

        public void Contains(Point point)
        {
            if ((point.X >= this.TopLeft[0] && point.X <= BottomRight[0]) 
                && (point.Y >= this.TopLeft[1] && point.Y <= BottomRight[1]))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            
        }
    }
}
