using CalorieCounter.Contracts;
using CalorieCounter.Models.Food;

namespace CalorieCounter.Factories
{
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0)
        {
            throw new System.NotImplementedException();
        }

        public IProduct CreateMeal(IProduct firstProduct, int firstProdWeight, IProduct secondProduct, int secondProdWeight)
        {
            throw new System.NotImplementedException();
        }

        public IProduct CreateProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}