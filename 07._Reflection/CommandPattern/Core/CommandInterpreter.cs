using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND = "Command";

        public string Read(string args)
        {
            var argsParts = args
                .Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);

            var commandName = argsParts[0] + COMMAND;

            var commandArgs = argsParts
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault
                (t => t.Name == commandName);

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
