using System;
using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    public static class DailyNutriCalc
    {
        public static int CalculateCurrentSugars(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(p => p.Sugar);
        }

        public static int CalculateCurrentFibers(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(p => p.Fiber);
        }

        public static double RemainingProteinIntake(double suggestedProteinDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentProteinIntake = productsConsumed.Sum(p => p.Protein);

            return suggestedProteinDailyIntake - currentProteinIntake;
        }

        public static double RemainingCarbsIntake(double suggestedCarbsDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentCarbIntake = productsConsumed.Sum(p => p.Carbs);

            return suggestedCarbsDailyIntake - currentCarbIntake;
        }

        public static double RemainingFatsIntake(double suggestedFatsDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentFatIntake = productsConsumed.Sum(p => p.Fat);
            return suggestedFatsDailyIntake - currentFatIntake;
        }

        public static int RemainingCaloriesIntake(int suggestedCaloriesDailyIntake, ICollection<IProduct> productsConsumed)
        {
            int currentCaloriesIntake = productsConsumed.Sum(p => p.Calories);

            return suggestedCaloriesDailyIntake - currentCaloriesIntake;
        }

        public static int RemainingWaterIntake(int suggestedDailyWaterIntake, int waterConsumed)
        {
            return suggestedDailyWaterIntake - waterConsumed;
        }

        public static string CalculateMacros(ICollection<IProduct> productsConsumed)
        {
            var totalCalories = productsConsumed.Sum(p => p.Calories);
            var totalCarbs = productsConsumed.Sum(p => p.Carbs);
            var totalProteins = productsConsumed.Sum(p => p.Protein);
            var totalFat = productsConsumed.Sum(p => p.Fat);

            var carbsRatio = Math.Round(((double)(totalCarbs * 4) / totalCalories) * 100);
            var proteinRatio = Math.Round(((double)(totalProteins * 4) / totalCalories) * 100);
            var fatRatio = Math.Round(((double)(totalFat * 9) / totalCalories) * 100);

            return $"Carbs:Protein:Fat = {carbsRatio}:{proteinRatio}:{fatRatio}";
        }
        //public static int CalculateCurrentCalories(ICollection<IProduct> productsConsumed)
        //{
        //    return  productsConsumed.Sum(p => p.Calories);
        //}
        //public static int CalculateCurrentProteins(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(p => p.Protein);
        //}
        //public static int CalculateCurrentCarbs(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(p => p.Carbs);
        //}
        //public static int CalculateCurrentFats(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(p => p.Fat);
        //}
    }
}