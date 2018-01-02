using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace Console_App.Core.Commands.Showing
{
    internal class ShowRemainingNutritientsCommand : BaseCommand
    {
        public ShowRemainingNutritientsCommand(ICalorieCounterEngine calorieCounterEngine) : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            return this.CalorieCounterEngine.GetDailyReport();
        }
    }
}