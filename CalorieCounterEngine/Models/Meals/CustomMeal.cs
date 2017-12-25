namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
    using CalorieCounterEngine.Contracts;

    public sealed class CustomMeal : Meal
    {
        public CustomMeal(ICollection<IProduct> products, MealType type) : base(products, type)
        {
            //TODO: Validations

            // Building the meal.
            foreach (var product in products)
            {
                this.Name += product.Name + " ";
                this.Calories += product.Calories;
                this.Carbs += product.Carbs;
                this.Fat += product.Fat;
                this.Fiber += product.Fiber;
                this.Protein += product.Protein;
                this.Sugar += product.Sugar;
            }
        }
    }
}