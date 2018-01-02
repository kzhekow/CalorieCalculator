using System.Collections.Generic;
using CalorieCounter.Contracts;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand(ICalorieCounterEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected ICalorieCounterEngine CalorieCounterEngine
        {
            get;
        }

        public abstract string Execute(IList<string> parameters);
    }
}