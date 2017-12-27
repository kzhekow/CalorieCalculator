using System;
using System.Collections.Generic;
using System.Text;
using CalorieCounter;
using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    /// <summary>
    ///     Parser class with the sole purpose of capturing user input and delegating it to the calorie counter engine.
    /// </summary>
    public sealed class ConsoleCommandParserEngine
    {
        /// <summary>
        ///     Reference to the engine that actually do the job.
        /// </summary>
        private readonly CalorieCounterEngine calorieCounterCalorieCounterEngineInstance = new CalorieCounterEngine();

        private ConsoleCommandParserEngine()
        {
        }

        public static ConsoleCommandParserEngine Instance { get; } = new ConsoleCommandParserEngine();

        public void Start()
        {
            throw new NotImplementedException();
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            var currentLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
                try
                {
                    var report = ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }

            return reports;
        }

        private string
            ProcessSingleCommand(
                ICommand command) /////////Here we should add all the commands that we intend our program to have. - Add meal to day etc.
        {
            var output = new StringBuilder();
            switch (command.Name)
            {
                case "CreateProduct":
                    //TODO: Validations if this is legit command call.

                    //boxing the arguments
                    var name = command.Parameters[0];
                    var weight = decimal.Parse(command.Parameters[1]);
                    var protein = int.Parse(command.Parameters[2]);
                    var carbs = int.Parse(command.Parameters[3]);
                    var fat = int.Parse(command.Parameters[4]);
                    var calories = int.Parse(command.Parameters[5]);
                    var sugar = int.Parse(command.Parameters[6]);
                    var fiber = int.Parse(command.Parameters[7]);
                    object parameters = new object[]{name, weight, protein, carbs, fat, calories, sugar, fiber};
                    this.calorieCounterCalorieCounterEngineInstance.CreateProductCommand.Execute(parameters);
                    break;

                default:
                    output.Append("Not Implemented");
                    break;
            }

            return output.ToString();
        }
    }
}