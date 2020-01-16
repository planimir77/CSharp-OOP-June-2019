using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokkens = command.Split();
                var department = tokkens[0];
                var firstName = tokkens[1];
                var secondName = tokkens[2];
                var patient = tokkens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool isMoreSpace = departments[department].SelectMany(x => x).Count() < 60;
                if (isMoreSpace)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);
                    for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
                    {
                        if (departments[department][currentRoom].Count < 3)
                        {
                            room = currentRoom;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
