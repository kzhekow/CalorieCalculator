namespace CalorieCounter.Models.Drinks
{
    /// <summary>
    ///     CustomDrink class inherits from IFood, because custom drink can have nutrition values.
    /// </summary>
    public class CustomDrink : Product
    {
        /// <summary>
        ///     CustomDrink constructor. We make sure that nutritients can not have a negative values.
        /// </summary>
        public CustomDrink(string name, int calories, int protein, int carbs, int fat, int sugar,
            int fiber) : base(name, calories, protein, carbs, fat, sugar, fiber)
        {
        }
    }
}