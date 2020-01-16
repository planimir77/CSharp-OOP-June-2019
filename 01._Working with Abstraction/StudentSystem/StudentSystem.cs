namespace StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; private set; }

        public void ReadCommand()
        {
            // ReSharper disable once PossibleNullReferenceException
            string[] command = Console.ReadLine().Split();

            switch (command[0])
            {
                case "Create":
                {
                    var name = command[1];
                    var age = int.Parse(command[2]);
                    var grade = double.Parse(command[3]);
                    if (!Students.ContainsKey(name))
                    {
                        var student = new Student(name, age, grade);
                        Students[name] = student;
                    }

                    break;
                }

                case "Show":
                {
                    var name = command[1];
                    if (Students.ContainsKey(name))
                    {
                        var student = Students[name];
                        
                        Console.WriteLine(student);
                    }

                    break;
                }

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
