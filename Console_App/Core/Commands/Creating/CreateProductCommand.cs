using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Commands.Creating
{
    public abstract class CreateProductCommand : ICommand
    {
        private readonly ICalorieCounterEngine calorieCounterEngine;

        public CreateProductCommand(ICalorieCounterEngine calorieCounterEngine)
        {
            this.calorieCounterEngine = calorieCounterEngine;
        }

        protected ICalorieCounterEngine CalorieCounterEngine => this.calorieCounterEngine;

        public abstract string Execute(IList<string> parameters);
    }
}
