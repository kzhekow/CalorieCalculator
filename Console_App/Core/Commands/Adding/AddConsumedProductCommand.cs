using System.Collections.Generic;
using Console_App.Core.Contracts;
using CalorieCounter.Contracts;
using System;

namespace Console_App.Core.Commands.Adding
{
    internal class AddConsumedProductCommand : ICommand
    {
        public AddConsumedProductCommand(ICalorieCounterEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected ICalorieCounterEngine CalorieCounterEngine { get; }

        public string Execute(IList<string> parameters)
        {
            string name;
            int weight;

            try
            {
                name = parameters[0];
                weight = int.Parse(parameters[1]);
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse AddConsumedProduct command parameters.");
            }

            object[] args = { name, weight };

            if (this.CalorieCounterEngine.AddConsumedProductCommand.CanExecute(args))
            {
               this.CalorieCounterEngine.AddConsumedProductCommand.Execute(args);
            }

            return $"Product {name} was added to your daily consumption";
        }
    }
}