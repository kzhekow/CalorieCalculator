using CalorieCounterEngine.Contracts;
using CalorieCounterEngine.Factories;
using CalorieCounterEngine.Models.Contracts;
using CalorieCounterEngine.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounterEngine.Core.Contracts;

namespace CalorieCounterEngine.Core.Engine
{
    public sealed class CalorieCalculatorEngine 
    {
        private static readonly CalorieCalculatorEngine SingleInstance = new CalorieCalculatorEngine();
        private readonly ProductFactory factory;
        private readonly IDictionary<string, IProduct> products;
        private readonly IDictionary<string, IActivity> activities;
        
        
        
        private CalorieCalculatorEngine()
        {
            this.factory = new ProductFactory();
            this.products = new Dictionary<string, IProduct>();
            this.activities = new Dictionary<string, IActivity>();
        }

        public static CalorieCalculatorEngine Instance => SingleInstance;

        public void start()
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
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {

                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private string ProcessSingleCommand(ICommand command) /////////Here we should add all the commands that we intend our program to have. - Add meal to day etc.
        {
            switch (command.Name)
            {
                default:
                    return "Not Implemented";
            }
        }

        
    }
}
