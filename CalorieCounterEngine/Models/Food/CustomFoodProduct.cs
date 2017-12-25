namespace CalorieCounterEngine.Models.Food
{
    public class CustomFoodProduct : Product
    {
        public CustomFoodProduct(string name, decimal weightInGrams, int calories, int protein, int carbs, int fat, int sugar, int fiber) : base(name, weight, calories, protein, carbs, fat, sugar, fiber)
        {
        }
    }
}
