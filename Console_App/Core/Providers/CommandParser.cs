
using CalorieCounter.Factories;
using CalorieCounterEngine.Factories;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Console_App.Core.Providers
{
    class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);

            if (!commandTypeInfo.Name.ToLower().Contains("goal") && !commandTypeInfo.Name.ToLower().Contains("activity"))
            {
                return Activator.CreateInstance(commandTypeInfo, ProductFactory.Instance, CommandParserEngine.Instance, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            }
            else if (!commandTypeInfo.Name.ToLower().Contains("goal") && !commandTypeInfo.Name.ToLower().Contains("drink") && !commandTypeInfo.Name.ToLower().Contains("food"))
            {
                return Activator.CreateInstance(commandTypeInfo, ActivityFactory.Instance, CommandParserEngine.Instance, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            }
            else
            {
                return Activator.CreateInstance(commandTypeInfo, GoalFactory.Instance, CommandParserEngine.Instance, CalorieCounter.CalorieCounterEngine.Instance) as ICommand;
            }


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
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
