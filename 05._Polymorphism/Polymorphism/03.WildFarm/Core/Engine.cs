using System;
using System.Collections.Generic;
using _03.WildFarm.Models.Animal;
using _03.WildFarm.Models.Animal.Bird;
using _03.WildFarm.Models.Animal.Mammal;
using _03.WildFarm.Models.Food.Entities;

namespace _03.WildFarm.Core
{
    public class Engine
    {
        private static List<Animal> animals = new List<Animal>();
        private static List<Food> foods = new List<Food>();

        public void Run()
        {
            var command = Console.ReadLine();
            while (command  != "End")
            {
                var currentAnimal = command
                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var animal = CreateAnimal(currentAnimal);
                animals.Add(animal);

                var currentFood = Console.ReadLine()
                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foods.Add(CreateFood(currentFood));

                command = Console.ReadLine();
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].AskFood());
                animals[i].Feed(foods[i]);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Food CreateFood(string[] args)
        {
            var food = args[0];

            switch (food)
            {
                case "Vegetable": return new Vegetable(int.Parse(args[1]));
                case "Fruit": return new Fruit(int.Parse(args[1]));
                case "Meat": return new Meat(int.Parse(args[1]));
                case "Seeds": return new Seeds(int.Parse(args[1]));
                default: return null;
            }
        }

        private static Animal CreateAnimal(string[] args)
        {
            var type = args[0];

            switch (type)
            {
                case "Hen": return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                
                case "Owl": return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                  
                case "Cat" :return new Cat(args[1], double.Parse(args[2]),args[3],args[4]);
                    
                case "Dog": return new Dog(args[1], double.Parse(args[2]), args[3]);

                case "Mouse": return new Mouse(args[1], double.Parse(args[2]), args[3]);
                    
                case "Tiger": return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);

                default: return null;
            }
        }

        
        
    }
}
