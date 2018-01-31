using System;
using System.Text;
using Console_App.Core.Contracts;
using Console_App.Core.Providers;

namespace Console_App.Core.Engine
{
    public class CommandParserEngine : ICommandParserEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private static CommandParserEngine instanceHolder;

        public CommandParserEngine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();
        }

        public static CommandParserEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new CommandParserEngine();
                }

                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }
        public IParser Parser { get; set; }

        public void Start()
        {
            PrintHelp();

            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                    PrintHelp();
                }
            }
        }

        private void PrintHelp()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Please enter one of the following commands: ");
            sb.AppendLine();
            sb.AppendLine($"- {EngineConstants.CreateFoodProduct} [name] [caloriesPer100g] [protPer100g] [carbPer100g] [fatPer100g] [sugarPer100g] [fiberPer100g]");
            sb.AppendLine($"- {EngineConstants.CreateDrink} [name] [caloriesPer100g] [protPer100g] [carbPer100g] [fatPer100g] [sugarPer100g] [fiberPer100g]");
            sb.AppendLine($"- {EngineConstants.SetGoal} [startingWeight] [goalWeight] [height] [age] [gender: male/female] [goalType: LoseWeight/MaintainWeight/GainWeight] [activityLevel: Light/Moderate/Heavy]");
            sb.AppendLine($"- {EngineConstants.CreateMeal} [product1] [prod1Weight] [product2] [prod2Weight] ... [productn] [prodnWeight]");
            sb.AppendLine($"- {EngineConstants.AddConsumedProduct} [name] [weight/ml]");
            sb.AppendLine($"- {EngineConstants.AddWater} [ml]");
            sb.AppendLine($"- {EngineConstants.AddActivity} [cardio/strength] [time]");
            sb.AppendLine($"- {EngineConstants.ShowAllProducts}");
            sb.Append($"- {EngineConstants.ShowRemainingNutrients}");

            Console.WriteLine(sb);
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}