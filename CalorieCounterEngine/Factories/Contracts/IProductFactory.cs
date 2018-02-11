using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace CalorieCounter.Factories.Contracts
{
    public interface IProductFactory
    {
        IProduct CreateFoodProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g,
            int fatPer100g, int sugar = 0, int fiber = 0);

        IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g,
            int sugar = 0, int fiber = 0);
    }
}