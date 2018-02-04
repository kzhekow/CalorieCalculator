using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.CustomException;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands.Adding
{
    internal class AddWaterCommand : ICommand
    {
        public AddWaterCommand(IEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected IEngine CalorieCounterEngine { get; }

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

            object[] args = {waterVolume};

            if (this.CalorieCounterEngine.AddWaterCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.AddWaterCommand.Execute(args);
            }

            return $"{waterVolume}ml was added to your daily water consumption";
        }
    }
}