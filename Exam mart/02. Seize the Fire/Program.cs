using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cells = Console.ReadLine().Split('#').ToList();
            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            double totalFire = 0;
            List<string> totalCells = new List<string> { "Cells:" };

            for (int i = 0; i < cells.Count; i++)
            {
                var arr = cells[i].Split(" = ").ToArray();
                int valueOfCell = int.Parse(arr[1]);
                string typeOfFire = arr[0];
                if (typeOfFire == "High" && valueOfCell>=81 && valueOfCell<=125 && water>= valueOfCell)
                {
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    string temp = " - " + valueOfCell;
                    totalCells.Add(temp);
                }
                else if (typeOfFire == "Medium" && valueOfCell >= 51 && valueOfCell <= 80 && water >= valueOfCell)
                {
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    string temp = " - " + valueOfCell;
                    totalCells.Add(temp);
                }
                else if (typeOfFire == "Low" && valueOfCell >= 1 && valueOfCell <= 50 && water >= valueOfCell)
                {
                    water -= valueOfCell;
                    effort += valueOfCell * 0.25;
                    totalFire += valueOfCell;
                    string temp = " - " + valueOfCell;
                    totalCells.Add(temp);
                }
            }
            foreach (var item in totalCells)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {(int)totalFire}");

        }
    }
}
