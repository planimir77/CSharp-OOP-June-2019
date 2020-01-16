using System;
using System.Linq;
using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private static MachinesManager manager;

        public void Run()
        {
            var input = Console.ReadLine();

            manager = new MachinesManager();

            while (input != "Quit")
            {
                var command = input?
                    .Split();

                if (command?[0] == "HirePilot")
                {
                    Console.WriteLine(manager.HirePilot(command[1]));
                }
                else if (command?[0] == "PilotReport")
                {
                    Console.WriteLine(manager.PilotReport(command[1]));
                }
                else if (command?[0] == "ManufactureTank")
                {
                    Console.WriteLine(manager
                        .ManufactureTank(command[1], 
                        double.Parse(command[2]),
                        double.Parse(command[3])));
                }
                else if (command?[0] == "ManufactureFighter")
                {
                    Console.WriteLine(manager
                        .ManufactureFighter(command[1],
                        double.Parse(command[2]),
                        double.Parse(command[3])));
                }
                else if (command?[0] == "MachineReport")
                {
                    Console.WriteLine(manager
                        .MachineReport(command[1]));
                }
                else if (command?[0] == "AggressiveMode")
                {
                    Console.WriteLine(manager
                        .ToggleFighterAggressiveMode(command[1]));
                }
                else if (command?[0] == "DefenseMode")
                {
                    Console.WriteLine(manager
                        .ToggleTankDefenseMode(command[1]));
                }
                else if (command?[0] == "Engage")
                {
                    Console.WriteLine(manager
                        .EngageMachine(command[1]
                    , command[2]));
                }
                else if (command?[0] == "Attack")
                {
                    Console.WriteLine(manager
                        .AttackMachines(command[1]
                            , command[2]));
                }

                input = Console.ReadLine();
            }
        }
    }
}
