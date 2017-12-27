namespace CalorieCounter.Models.Food
{
    public class CustomFoodProduct : Product
    {
        public CustomFoodProduct(string name, decimal weightInGrams, int calories, int protein, int carbs, int fat,
            int sugar, int fiber) : base(name, weightInGrams, calories, protein, carbs, fat, sugar, fiber)
        {
        }
    }
}