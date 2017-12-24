namespace CalorieCounterEngine.Factories
{
    using global::CalorieCounterEngine.Contracts;
    using global::CalorieCounterEngine.Models;

    public class ProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string name, int protein, int carbs, int fat, int calories, int sugar = 0, int fiber = 0)
        {
            // TODO: Validations?
            return new CustomProduct(name, protein, carbs, fat, calories, sugar, fiber);
        }
    }
}
