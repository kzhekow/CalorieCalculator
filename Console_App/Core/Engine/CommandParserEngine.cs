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
        private IConsoleParser parser;

        public CommandParserEngine(IConsoleReader reader, IConsoleWriter writer, IConsoleParser parser)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Parser = parser;
        }

        public IConsoleReader Reader
        {

            get
            {
                return reader;
            }
            set
            {
                if (this.reader == null)
                {
                    throw new NullReferenceException();
                }
                this.reader = value;
            }
        }
        public IConsoleWriter Writer
        {

            get
            {      
                return writer;
            }
            set
            {
                if (this.writer == null)
                {
                    throw new NullReferenceException();
                }
                this.writer = value;
            }
        }
        public IConsoleParser Parser
        {

            get
            {
                return parser;
            }
            set
            {
                if (this.parser == null)
                {
                    throw new NullReferenceException();
                }
                this.parser = value;
            }
        }

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