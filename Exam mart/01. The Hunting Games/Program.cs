using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int countOfPeople = int.Parse(Console.ReadLine());
            double energyLevel = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());
            double totalWater = (double)days * (double)countOfPeople * water;
            double totalFood = (double)days * (double)countOfPeople * food;
            for (int day = 1; day <= days; day++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                energyLevel -= energyLoss;
                double tempWater = 0;
                double tempFood = 0;
                if (day%2==0)
                {
                    energyLevel += energyLevel * 0.05;
                    tempWater = totalWater;
                    totalWater = totalWater * 0.7; 

                }
                if (day % 3== 0)
                {
                    tempFood = totalFood;
                    totalFood = totalFood-(totalFood / (double)countOfPeople);
                    energyLevel *= 1.10;
                }
                if (energyLevel<=0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    return;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {energyLevel:F2} energy!");
        }
    }
}
