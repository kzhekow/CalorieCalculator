using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models;
using CalorieCounter.Models.Drinks;
using CalorieCounter.Models.Food;

namespace CalorieCounter.Factories
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0)
        {
            return new CustomDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatPer100g, sugar, fiber);
        }

        public IProduct CreateMeal(ICollection<IProduct> products, MealType type, string name)
        {
            return new CustomMeal(products, type, name);
        }

        public IProduct CreateProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0)
        {
            return new CustomFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatPer100g, sugar, fiber);
        }


    }
}