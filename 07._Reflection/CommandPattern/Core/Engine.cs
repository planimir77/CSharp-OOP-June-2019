using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {

        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();

                var result = this.commandInterpreter.Read(commandLine);

                Console.WriteLine(result);
            }
        }
    }
}
