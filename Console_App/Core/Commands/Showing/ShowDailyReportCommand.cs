using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace Console_App.Core.Commands.Showing
{
    internal class ShowDailyReportCommand : BaseCommand
    {
        public ShowDailyReportCommand(ICalorieCounterEngine calorieCounterEngine)
            : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var dailyReport = this.CalorieCounterEngine.GetDailyReport();

            return dailyReport;
        }

    }
}