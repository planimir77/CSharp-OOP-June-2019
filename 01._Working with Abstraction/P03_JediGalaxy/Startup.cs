namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static int[,] matrix;
        public static void Main()
        {
            int[] dimension = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimension[0];
            int cols = dimension[1];

            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }

            string command = Console.ReadLine();

            long totalSum = 0;

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsCoordinatesInside(evilRow, evilCol))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int playerRow = playerCoordinates[0];
                int plaerCol= playerCoordinates[1];

                while (playerRow >= 0 && plaerCol < matrix.GetLength(1))
                {
                    if (IsCoordinatesInside(playerRow, plaerCol))
                    {
                        totalSum += matrix[playerRow, plaerCol];
                    }

                    plaerCol++;
                    playerRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);

        }

        private static bool IsCoordinatesInside(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                             && col >= 0 
                             && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
