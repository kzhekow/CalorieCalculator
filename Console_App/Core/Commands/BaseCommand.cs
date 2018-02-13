using System.Collections.Generic;
using CalorieCounter.Contracts;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand(IEngine calorieCounterEngine)
        {
            this.CalorieCounterEngine = calorieCounterEngine;
        }

        protected IEngine CalorieCounterEngine { get; }

        public abstract string Execute(IList<string> parameters);
    }
}