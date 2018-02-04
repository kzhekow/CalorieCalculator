using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using System.Collections.Generic;

namespace CalorieCounterEngine.Contracts
{
    public interface IDailyNutriCalc
    {
        int CalculateCurrentSugars(ICollection<IProduct> productsConsumed);

        int CalculateCurrentFibers(ICollection<IProduct> productsConsumed);

        double RemainingProteinIntake(double suggestedProteinDailyIntake, ICollection<IProduct> productsConsumed);

        double RemainingCarbsIntake(double suggestedCarbsDailyIntake, ICollection<IProduct> productsConsumed);

        double RemainingFatsIntake(double suggestedFatsDailyIntake, ICollection<IProduct> productsConsumed);

        double RemainingCaloriesIntake(
            double suggestedCaloriesDailyIntake,
            ICollection<IProduct> productsConsumed,
            ICollection<IActivity> activitiesPerformed = null);

        int RemainingWaterIntake(int suggestedDailyWaterIntake, int waterConsumed);

        string CurrentDayMacrosRatio(ICollection<IProduct> productsConsumed);
    }
}
