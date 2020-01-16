using System;
using System.Collections.Generic;
using System.Linq;
using _06.BirthdayCelebrations.Interfaces;
using _06.BirthdayCelebrations.Model;

namespace _06.BirthdayCelebrations.Core
{
    public class Engine
    {
        List<IPet> ids = new List<IPet>();

        public Engine()
        {
            
        }

        public void Run()
        {
            var input = Console.ReadLine();

            GetId(input, ids);

            var lastDigit = Console.ReadLine();

            PrintId(ids, lastDigit);
        }

        public static void PrintId(List<IPet> ids, string lastDigit)
        {
            //bool isEmptyOutput = true;
            foreach (IPet id in ids.Where(i => i.BirthDate.EndsWith(lastDigit)))
            {
                Console.WriteLine(id.BirthDate);
                //isEmptyOutput = false;
            }

            //if (isEmptyOutput)
            //{
            //    Console.WriteLine("<empty output>");
            //}
        }   //

        public static void GetId(string input, List<IPet> ids)
        {
            while (input != "End")
            {
                var current = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

               
                if (current != null && current.Contains("Citizen"))
                {
                    var name = current[1];
                    var age = int.Parse(current[2]);
                    var id = current[3];
                    var birthDate = current[4];

                    var citizen = new Citizen( name, age, id, birthDate);
                    ids.Add(citizen);
                }
                else if (current != null && current.Contains("Pet"))
                {
                    var name = current[1];
                    var birthDate = current[2];
                    IPet pet = new Pet(name, birthDate);
                    ids.Add(pet);
                }

                input = Console.ReadLine();
            }
        }
    }
}
