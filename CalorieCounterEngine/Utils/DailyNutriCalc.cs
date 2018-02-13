using System;
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
            if (productsConsumed != null)
            {
                return productsConsumed.Sum(p => p.Sugar);
            }

            return 0;
        }

        public int CalculateCurrentFibers(ICollection<IProduct> productsConsumed)
        {
            if (productsConsumed != null)
            {
                return productsConsumed.Sum(p => p.Fiber);
            }

            return 0;
        }

        public double RemainingProteinIntake(double suggestedProteinDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            if (productsConsumed != null)
            {
                double currentProteinIntake = productsConsumed.Sum(p => p.Protein);

                return suggestedProteinDailyIntake - currentProteinIntake;
            }

            return suggestedProteinDailyIntake;
        }

        public double RemainingCarbsIntake(double suggestedCarbsDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            if (productsConsumed != null)
            {
                double currentCarbIntake = productsConsumed.Sum(p => p.Carbs);

                return suggestedCarbsDailyIntake - currentCarbIntake;
            }

            return suggestedCarbsDailyIntake;
        }

        public double RemainingFatsIntake(double suggestedFatsDailyIntake,
            ICollection<IProduct> productsConsumed)
        {
            if (productsConsumed != null)
            {
                double currentFatIntake = productsConsumed.Sum(p => p.Fat);
                return suggestedFatsDailyIntake - currentFatIntake;
            }

            return suggestedFatsDailyIntake;
        }

        public double RemainingCaloriesIntake(double suggestedCaloriesDailyIntake,
            ICollection<IProduct> productsConsumed, ICollection<IActivity> activitiesPerformed = null)
        {
            if (activitiesPerformed != null)
            {
                var burnedCaloriesFromActivities = activitiesPerformed.Sum(a => a.CalculateBurnedCalories());

                suggestedCaloriesDailyIntake += burnedCaloriesFromActivities;
            }

            if (productsConsumed != null)
            {
                var currentCaloriesIntake = productsConsumed.Sum(p => p.Calories);


                return suggestedCaloriesDailyIntake - currentCaloriesIntake;
            }

            return suggestedCaloriesDailyIntake;
        }

        public int RemainingWaterIntake(int suggestedDailyWaterIntake, int waterConsumed)
        {
            if (waterConsumed < 0)
            {
                throw new ArgumentException("Water consumed can not be a negative number!");
            }

            return suggestedDailyWaterIntake - waterConsumed;
        }

        public string CurrentDayMacrosRatio(ICollection<IProduct> productsConsumed)
        {
            double totalCarbsCalories = productsConsumed.Sum(p => p.Carbs) * 4;
            double totalProteinsCalories = productsConsumed.Sum(p => p.Protein) * 4;
            double totalFatCalories = productsConsumed.Sum(p => p.Fat) * 9;
            var totalCalories = totalCarbsCalories + totalProteinsCalories + totalFatCalories;

            var carbsRatio = Math.Round(totalCarbsCalories / totalCalories * 100);
            var proteinRatio = Math.Round(totalProteinsCalories / totalCalories * 100);
            var fatRatio = Math.Round(totalFatCalories / totalCalories * 100);

            return $"Carbs:Protein:Fat = {carbsRatio}:{proteinRatio}:{fatRatio}";
        }
    }
}