using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    public sealed class CustomMeal : Meal
    {
        public CustomMeal(string products, MealType type, string name) 
            : base(products, type, name)
        {
            //TODO: Validations

            // Building the meal.
            //foreach (var product in products)
            //{
            //    this.Name += product.Name + " ";
            //    this.Calories += product.Calories;
            //    this.Carbs += product.Carbs;
            //    this.Fat += product.Fat;
            //    this.Fiber += product.Fiber;
            //    this.Protein += product.Protein;
            //    this.Sugar += product.Sugar;
            //}
        }
    }
}