using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(@"^([#$%&\*])([A-zA-z]+)([#$%&\*])=([\d]+)!!([\w\W\d]+)");
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string firstSimbol = match.Groups[1].ToString();
                    string secondSimbol = match.Groups[3].ToString();
                    string nameOfRacer = match.Groups[2].ToString();
                    int number = int.Parse(match.Groups[4].ToString());
                    string message = match.Groups[5].ToString();
                    if (firstSimbol == secondSimbol && message.Length == number)
                    {
                        //Encrypt message
                        var geohashcode = new StringBuilder();
                        foreach (var item in message)
                        {
                            char sing = Convert.ToChar(item + number);
                            geohashcode.Append(sing);
                        }
                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {geohashcode}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

            }
        }
    }
}
