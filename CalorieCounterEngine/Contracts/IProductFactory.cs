namespace CalorieCounter.Contracts
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0);
        IProduct CreateMeal(IProduct firstProduct, int firstProdWeight, IProduct secondProduct, int secondProdWeight);
        IProduct CreateDrink(string name, int caloriesPer100g, int proteinPer100g, int carbsPer100g, int fatPer100g, int sugar = 0, int fiber = 0);
    }
}