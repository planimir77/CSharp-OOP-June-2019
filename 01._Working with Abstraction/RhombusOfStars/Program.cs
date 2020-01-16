namespace RhombusOfStars
{
    using System;

    public class Program
    {
        public static int rhombusSize = 0;
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            rhombusSize = size;
            PrintRow();
        }

        private static void PrintRow()
        {
            PrintUpperPart();
            PrintBottomPart();
        }

        private static void PrintBottomPart()
        {
            for (int row = 0; row < rhombusSize-1; row++)
            {
                for (int space = 0; space < row+1; space++)
                {
                    Console.Write(" ");
                }

                for (int asterix = 0; asterix < rhombusSize-1-row; asterix++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintUpperPart()
        {
            for (int row = 0; row < rhombusSize; row++)
            {
                for (int i = 0; i < rhombusSize-1-row; i++)
                {
                    Console.Write(" ");
                }
                for (int col = 0; col < row+1; col++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }
    }
}
