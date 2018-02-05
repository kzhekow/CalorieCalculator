using System;
using System.Text;
using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    public class CommandParserEngine : ICommandParserEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private IConsoleReader reader;
        private IConsoleWriter writer;
        private ICommandParser parser;

        public CommandParserEngine(IConsoleReader reader, IConsoleWriter writer, ICommandParser parser)
        {
            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
        }


        public void Start()
        {
            PrintHelp();

            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                    PrintHelp();
                }
            }
        }

        private void PrintHelp()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Please enter one of the following commands: ");
            sb.AppendLine();
            sb.AppendLine($"- {EngineConstants.SetGoal} [startingWeight] [goalWeight] [height] [age] [gender: male/female] [goalType: LoseWeight/MaintainWeight/GainWeight] [activityLevel: Light/Moderate/Heavy]");
            sb.AppendLine($"- {EngineConstants.CreateFoodProduct} [name] [caloriesPer100g] [protPer100g] [carbPer100g] [fatPer100g] [sugarPer100g] [fiberPer100g]");
            sb.AppendLine($"- {EngineConstants.CreateDrink} [name] [caloriesPer100g] [protPer100g] [carbPer100g] [fatPer100g] [sugarPer100g] [fiberPer100g]");
            sb.AppendLine($"- {EngineConstants.CreateMeal} [product1] [prod1Weight] [product2] [prod2Weight] ... [productn] [prodnWeight]");
            sb.AppendLine($"- {EngineConstants.AddConsumedProduct} [name] [weight/ml]");
            sb.AppendLine($"- {EngineConstants.AddWater} [ml]");
            sb.AppendLine($"- {EngineConstants.AddActivity} [cardio/strength] [time]");
            sb.AppendLine($"- {EngineConstants.ShowAllProducts}");
            sb.AppendLine($"- {EngineConstants.ShowDailyReport}");
            sb.Append($"- {EngineConstants.ShowRemainingNutrients}");

            Console.WriteLine(sb);
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.writer.WriteLine(executionResult);
        }
    }
}