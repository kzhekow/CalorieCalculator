using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    public static class DailyNutriCalc
    {
        public static int CalculateCurrentCalories(ICollection<IProduct> productsConsumed)
        {
            return  productsConsumed.Sum(x => x.Calories);
        }
        public static int CalculateCurrentProteins(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Protein);
        }
        public static int CalculateCurrentCarbs(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Carbs);
        }
        public static int CalculateCurrentSugars(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Sugar);
        }
        public static int CalculateCurrentFibers(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Fiber);
        }
        public static int CalculateCurrentFats(ICollection<IProduct> productsConsumed)
        {
            return productsConsumed.Sum(x => x.Fat);
        }

    }
}