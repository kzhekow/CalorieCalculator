namespace CalorieCounterEngine.Contracts
{
    public interface IFood : IProduct
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        int Fiber { get; }
    }
}
