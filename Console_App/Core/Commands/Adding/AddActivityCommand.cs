using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.CustomException;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands.Adding
{
    internal class AddActivityCommand : ICommand
    {
        public AddActivityCommand(IEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected IEngine CalorieCounterEngine { get; }

        public string Execute(IList<string> parameters)
        {
            string activityType;
            int time;

            try
            {
                activityType = parameters[0];
                time = int.Parse(parameters[1]);
            }
            catch (Exception)
            {
                throw new CommandParseЕxception("The correct format for AddActivity is {ActivityType}{time}");
            }

            object[] args = {activityType, time};

            if (this.CalorieCounterEngine.AddActivityCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.AddActivityCommand.Execute(args);
            }

            return $"Your activity was added";
        }
    }
}