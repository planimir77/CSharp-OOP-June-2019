using System;
using System.Threading;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        static ConsoleKeyInfo consoleKeyInfo;
        private const char spaceShipSymbol = 'Ж';

        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            
            Wall wall = new Wall(60, 18);

            wall.InitializeWallBorders();
            
            SpaceShip spaceShip = new SpaceShip(30, 17);
            
            spaceShip.Draw(spaceShipSymbol);

            do
            {
                spaceShip.MoveShoots();

                if (Console.KeyAvailable)
                {
                    consoleKeyInfo = Console.ReadKey();

                    if (consoleKeyInfo.Key == ConsoleKey.LeftArrow && spaceShip.LeftX > 2)
                    {
                        spaceShip.Draw(' ');
                        spaceShip.LeftX--;
                        spaceShip.Draw(spaceShipSymbol);
                    }
                    else if (consoleKeyInfo.Key == ConsoleKey.RightArrow && spaceShip.LeftX < 56)
                    {
                        spaceShip.Draw(' ');
                        spaceShip.LeftX++;
                        spaceShip.Draw(spaceShipSymbol);
                    }
                    else if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                    {
                        spaceShip.Shoot();
                        Thread.Sleep(5);
                    }
                }

            } while (true);
            
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
