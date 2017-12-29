using System;
using System.Collections.Generic;
using System.Text;
using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    using global::CalorieCounter;
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
            ProcessSingleCommand(ICommand command) /////////Here we should add all the commands that we intend our program to have. - Add meal to day etc.
        {
            var output = new StringBuilder();
            switch (command.Name)
            {
                case "CreateProduct":
                    //TODO: Validations if this is legit command call.

                    //boxing the arguments
                    var name = command.Parameters[0];
                    var calories = int.Parse(command.Parameters[1]);
                    var protein = int.Parse(command.Parameters[2]);
                    var carbs = int.Parse(command.Parameters[3]);
                    var fat = int.Parse(command.Parameters[4]);
                    var sugar = int.Parse(command.Parameters[5]);
                    var fiber = int.Parse(command.Parameters[6]);
                    object parameters = new object[] { name, calories, protein, carbs, fat, sugar, fiber };
                    this.calorieCounterCalorieCounterEngineInstance.CreateProductCommand.Execute(parameters);
                    break;
                case "CreateDrink":
                    var nameOfDrink = command.Parameters[0];
                    var caloriesOfDrink = int.Parse(command.Parameters[1]);
                    var proteinOfDrink = int.Parse(command.Parameters[2]);
                    var carbsOfDrink = int.Parse(command.Parameters[3]);
                    var fatOfDrink = int.Parse(command.Parameters[4]);
                    var sugarOfDrink = int.Parse(command.Parameters[5]);
                    var fiberOfDrink = int.Parse(command.Parameters[6]);
                    object parametersOfDrink = new object[] { nameOfDrink, caloriesOfDrink, proteinOfDrink, carbsOfDrink, fatOfDrink, sugarOfDrink, fiberOfDrink };
                    this.calorieCounterCalorieCounterEngineInstance.CreateProductCommand.Execute(parametersOfDrink);
                    break;
                case "CreateMeal":
                    throw new NotImplementedException();
                case "AddWater":
                    throw new NotImplementedException();
                case "AddConsumedProduct":
                    throw new NotImplementedException();
                case "RemoveProduct":
                    throw new NotImplementedException();
                case "AddActivity":
                    throw new NotImplementedException();
                case "ShowAllProducts":
                    throw new NotImplementedException();
                case "ShowRemaningNutrients":
                    throw new NotImplementedException();
                case "CreateGoal":
                    throw new NotImplementedException();

                default:
                    output.Append("Not Implemented");
                    break;
            }

            return output.ToString();
        }
    }
}