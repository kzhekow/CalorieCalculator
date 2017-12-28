using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    public static class DailyNutriCalc
    {
        public static int CalculateCurrentSugars(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Sugar);
        }

        public static int CalculateCurrentFibers(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Fiber);
        }

        public static double RemainingProteinIntake(double suggestedProteinDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentProteinIntake = productsConsumed.Sum(x => x.Protein);

            return suggestedProteinDailyIntake - currentProteinIntake;
        }

        public static double RemainingCarbsIntake(double suggestedCarbsDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentCarbIntake = productsConsumed.Sum(x => x.Carbs);

            return suggestedCarbsDailyIntake - currentCarbIntake;
        }

        public static double RemainingFatsIntake(double suggestedFatsDailyIntake, ICollection<IProduct> productsConsumed)
        {
            double currentFatIntake = productsConsumed.Sum(x => x.Fat);
            return suggestedFatsDailyIntake - currentFatIntake;
        }

        public static int RemainingCaloriesIntake(int suggestedCaloriesDailyIntake, ICollection<IProduct> productsConsumed)
        {
            int currentCaloriesIntake = productsConsumed.Sum(x => x.Calories);

            return suggestedCaloriesDailyIntake - currentCaloriesIntake;
        }

        public static int RemainingWaterIntake(int suggestedDailyWaterIntake, int waterConsumed)
        {
            return suggestedDailyWaterIntake - waterConsumed;
        }
        //public static int CalculateCurrentCalories(ICollection<IProduct> productsConsumed)
        //{
        //    return  productsConsumed.Sum(x => x.Calories);
        //}
        //public static int CalculateCurrentProteins(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(x => x.Protein);
        //}
        //public static int CalculateCurrentCarbs(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(x => x.Carbs);
        //}
        //public static int CalculateCurrentFats(ICollection<IProduct> productsConsumed)
        //{
        //    return productsConsumed.Sum(x => x.Fat);
        //}
    }
}