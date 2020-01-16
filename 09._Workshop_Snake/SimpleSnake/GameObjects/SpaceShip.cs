using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace SimpleSnake.GameObjects
{
    public class SpaceShip:Point
    {
        private const char shotSymbol = '*';
        private const char space = ' ';
        private readonly Queue<Point> shoots;

        public SpaceShip(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.shoots = new Queue<Point>();
        }
        
        public void Shoot()
        {
            Point shoot = new Point(this.LeftX, this.TopY - 1);

            shoot.Draw(shotSymbol);

            this.shoots.Enqueue(shoot);
        }

        public void MoveShoots()
        {
            if (this.shoots.Count > 0)
            {
                if (this.shoots.Count < 5)
                {
                    Thread.Sleep(40);
                }
                else if (this.shoots.Count < 7)
                {
                    Thread.Sleep(30);
                }
                else if (this.shoots.Count < 10)
                {
                    Thread.Sleep(20);
                }

                Point shoot = this.shoots.Dequeue();
                shoot.Draw(space);
                shoot.TopY--;
                if (shoot.TopY > 0)
                {
                    shoot.Draw(shotSymbol);
                    this.shoots.Enqueue(shoot);
                }

            }
        }
    }
}
