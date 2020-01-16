using System;
using System.Collections.Generic;
using System.Linq;
using _05.BorderControl.Interfaces;
using _05.BorderControl.Model;

namespace _05.BorderControl.Core
{
    public class Engine
    {
        List<IId> ids = new List<IId>();

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

        public static void PrintId(List<IId> ids, string lastDigit)
        {
            foreach (IId id in ids.Where(i => i.Id.EndsWith(lastDigit)))
            {
                Console.WriteLine(id.Id);
            }
        }

        public static void GetId(string input, List<IId> ids)
        {
            while (input != "End")
            {
                var current = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (current?.Length == 2)
                {
                    var model = current[0];
                    var id = current[1];
                    var robot = new Robot(id,model);
                    ids.Add(robot);
                }
                else if (current?.Length == 3)
                {
                    var name = current[0];
                    var age = int.Parse(current[1]);
                    var id = current[2];
                    var citizen = new Citizen(id, name, age);
                    ids.Add(citizen);
                }

                input = Console.ReadLine();
            }
        }
    }
}
