namespace CalorieCounterEngine.Contracts
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, decimal weight, int protein, int carbs, int fat, int calories, int sugar = 0, int fiber = 0);
    }
}
