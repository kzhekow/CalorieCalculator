using CalorieCounter.Contracts;
using CalorieCounterEngine.CustomException;
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
                throw new CommandParseЕxception("The correct format for AddWater is {volume}.");
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