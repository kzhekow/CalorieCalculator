using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace Console_App.Core.Commands.Showing
{
    internal class ShowRemainingNutrientsCommand : BaseCommand
    {
        public ShowRemainingNutrientsCommand(IEngine calorieCounterEngine)
            : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var dailyNutrientsReport = this.CalorieCounterEngine.GetRemainingNutrients();

            return dailyNutrientsReport;
        }

    }
}