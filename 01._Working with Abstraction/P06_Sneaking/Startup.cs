namespace Sneaking
{
    using System;

    public class Sneaking
    {
        private static char[][] _room;

        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            _room = new char[rows][];

            for (var row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()?
                    .ToCharArray();

                // ReSharper disable once PossibleNullReferenceException
                _room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    _room[row][col] = input[col];
                }
            }

            var moves = Console.ReadLine()?
                .ToCharArray();

            var samPosition = new int[2];

            for (int row = 0; row < _room.Length; row++)
            {
                for (int col = 0; col < _room[row].Length; col++)
                {
                    if (_room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
            for (int i = 0; i < moves?.Length; i++)
            {
                for (int row = 0; row < _room.Length; row++)
                {
                    for (int col = 0; col < _room[row].Length; col++)
                    {
                        if (_room[row][col] == 'b')
                        {
                            if (row >= 0 && row < _room.Length && col + 1 >= 0 && col + 1 < _room[row].Length)
                            {
                                _room[row][col] = '.';
                                _room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                _room[row][col] = 'd';
                            }
                        }
                        else if (_room[row][col] == 'd')
                        {
                            if (row >= 0 && row < _room.Length && col - 1 >= 0 && col - 1 < _room[row].Length)
                            {
                                _room[row][col] = '.';
                                _room[row][col - 1] = 'd';
                            }
                            else
                            {
                                _room[row][col] = 'b';
                            }
                        }
                    }
                }

                var getEnemy = new int[2];
                for (int j = 0; j < _room[samPosition[0]].Length; j++)
                {
                    if (_room[samPosition[0]][j] != '.' && _room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }
                if (samPosition[1] < getEnemy[1] && _room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    _room[samPosition[0]][samPosition[1]] = 'X';

                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    PrintFinalState();
                    
                    Environment.Exit(0);
                }
                else if (getEnemy[1] < samPosition[1] && _room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    _room[samPosition[0]][samPosition[1]] = 'X';

                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    PrintFinalState();

                    Environment.Exit(0);
                }


                _room[samPosition[0]][samPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                }
                _room[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < _room[samPosition[0]].Length; j++)
                {
                    if (_room[samPosition[0]][j] != '.' && _room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }
                if (_room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    _room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintFinalState();

                    Environment.Exit(0);
                }
            }
        }

        private static void PrintFinalState()
        {
            foreach (var row in _room)
            {
                Console.WriteLine(String.Join("",row));
            }
        }
    }
}
