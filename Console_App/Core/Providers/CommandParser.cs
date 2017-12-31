using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CalorieCounter;
using Console_App.Core.Contracts;

namespace Console_App.Core.Providers
{
    internal class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = FindCommand(commandName);

            //if (!commandTypeInfo.Name.ToLower().Contains("goal") && !commandTypeInfo.Name.ToLower().Contains("activity"))
            //{
            //    return Activator.CreateInstance(commandTypeInfo, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            //}
            //else if (!commandTypeInfo.Name.ToLower().Contains("goal") && !commandTypeInfo.Name.ToLower().Contains("drink") && !commandTypeInfo.Name.ToLower().Contains("food"))
            //{
            //    return Activator.CreateInstance(commandTypeInfo, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            //}
            //else
            //{
            //    return Activator.CreateInstance(commandTypeInfo, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            //}

            return Activator.CreateInstance(commandTypeInfo, CalorieCounterEngine.Instance) as ICommand;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == commandName.ToLower() + "command")
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}