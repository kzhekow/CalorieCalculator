using CalorieCounter.Contracts;
using Console_App.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Console_App.Core.Commands.Adding
{
    internal class AddWaterCommand : ICommand
    {
        public AddWaterCommand(ICalorieCounterEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected ICalorieCounterEngine CalorieCounterEngine { get; }

        public string Execute(IList<string> parameters)
        {
            int waterVolume;

            try
            {
                waterVolume = int.Parse(parameters[0]);
                
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse AddActivity command parameters.");
            }

            object[] args = { waterVolume };

            if (this.CalorieCounterEngine.AddWaterCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.AddWaterCommand.Execute(args);
            }

            return $"{waterVolume}ml was added to your daily water consumption";
        }
    }
}