using CalorieCounter.Contracts;
using System.Collections.Generic;

namespace CalorieCounter.Factories.Contracts
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0);
        IProduct CreateMeal(ICollection<IProduct> products, MealType type, string name);
        IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0);
    }
}