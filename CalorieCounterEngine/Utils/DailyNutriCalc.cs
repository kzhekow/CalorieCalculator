using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;

namespace CalorieCounter.Models.Utils
{
    public class DailyNutriCalc : IDailyNutriCalc
    {
        public int CalculateCurrentSugars(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(p => p.Sugar);
        }

        public int CalculateCurrentFibers(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(p => p.Fiber);
        }

        public double RemainingProteinIntake(double suggestedProteinDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            double currentProteinIntake = productsConsumed.Sum(p => p.Protein);

            return suggestedProteinDailyIntake - currentProteinIntake;
        }

        public double RemainingCarbsIntake(double suggestedCarbsDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            double currentCarbIntake = productsConsumed.Sum(p => p.Carbs);

            return suggestedCarbsDailyIntake - currentCarbIntake;
        }

        public double RemainingFatsIntake(double suggestedFatsDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            double currentFatIntake = productsConsumed.Sum(p => p.Fat);
            return suggestedFatsDailyIntake - currentFatIntake;
        }

        public double RemainingCaloriesIntake(double suggestedCaloriesDailyIntake,
            ICollection<IProduct> productsConsumed, ICollection<IActivity> activitiesPerformed = null)
        {
            var currentCaloriesIntake = productsConsumed.Sum(p => p.Calories);
            if (activitiesPerformed != null)
            {
                var burnedCaloriesFromActivities = activitiesPerformed.Sum(a => a.CalculateBurnedCalories());

                return suggestedCaloriesDailyIntake + burnedCaloriesFromActivities - currentCaloriesIntake;
            }

            return suggestedCaloriesDailyIntake - currentCaloriesIntake;
        }

        public int RemainingWaterIntake(int suggestedDailyWaterIntake, int waterConsumed)
        {
            return suggestedDailyWaterIntake - waterConsumed;
        }

        public string CurrentDayMacrosRatio(ICollection<IProduct> productsConsumed)
        {
            double totalCarbsCalories = productsConsumed.Sum(p => p.Carbs) * 4;
            double totalProteinsCalories = productsConsumed.Sum(p => p.Protein) * 4;
            double totalFatCalories = productsConsumed.Sum(p => p.Fat) * 9;
            double totalCalories = totalCarbsCalories + totalProteinsCalories + totalFatCalories;

            var carbsRatio = (int)((totalCarbsCalories / totalCalories) * 100);
            var proteinRatio = (int)((totalProteinsCalories / totalCalories) * 100);
            var fatRatio = (int)((totalFatCalories / totalCalories) * 100);

            return $"Carbs:Protein:Fat = {carbsRatio}:{proteinRatio}:{fatRatio}";
        }
    }
}