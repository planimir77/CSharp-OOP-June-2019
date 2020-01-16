namespace PointInRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Point
    {
        public Point(int[] points)
        {
            X = points[0];
            Y = points[1];
        }

        public int X { get; set; }

        public int Y { get; set; }

    }
}
