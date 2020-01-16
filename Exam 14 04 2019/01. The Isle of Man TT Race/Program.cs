using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var roadAndRacers = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                string[] tokken = input.Split("->");
                if (tokken[0] == "Add")
                {
                    string road = tokken[1];
                    string racer = tokken[2];
                    if (!roadAndRacers.ContainsKey(road))
                    {
                        roadAndRacers.Add(road, new List<string>());
                    }
                    roadAndRacers[road].Add(racer);
                }
                else if (tokken[0] == "Move")
                {
                    string road = tokken[1];
                    string racer = tokken[2];
                    string newRoad = tokken[3];
                    if (roadAndRacers[road].Contains(racer))
                    {
                        roadAndRacers[road].Remove(racer);
                        roadAndRacers[newRoad].Add(racer);
                    }
                }
                else if (tokken[0] == "Close")
                {
                    string road = tokken[1];
                    roadAndRacers.Remove(road);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Practice sessions:");
            foreach (var road in roadAndRacers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{road.Key}");
                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
