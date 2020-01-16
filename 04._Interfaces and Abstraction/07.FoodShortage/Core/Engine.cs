using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using _07.FoodShortage.Interface;
using _07.FoodShortage.Model;

namespace _07.FoodShortage.Core
{
    public class Engine
    {
        static HashSet<IBuyer> people = new HashSet<IBuyer>();

        public Engine()
        {
            
        }

        public void Run()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            GetPeople(numberOfPeople);

            BoughtFood();
            Console.WriteLine(people.Sum(p=>p.Food));
            ;
        }

        private void BoughtFood()
        {
            var person = Console.ReadLine();
            while (person != "End")
            {
                if (people.Contains(people.FirstOrDefault(p=>p.Name == person)))
                {
                    people.FirstOrDefault(p => p.Name == person)?.BuyFood();
                }

                person = Console.ReadLine();
            }
        }

        private static void GetPeople(int numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                var person = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = person[0];
                var age = int.Parse(person[1]);

                if (person.Length == 3)
                {
                    var group = person[2];

                    IBuyer rebel = new Rebel(name, age, group);

                    people.Add(rebel);
                }
                else if (person.Length == 4)
                {
                    var id = person[2];
                    var birthdate = person[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);

                    people.Add(citizen);
                }
            }
        }
    }
}
