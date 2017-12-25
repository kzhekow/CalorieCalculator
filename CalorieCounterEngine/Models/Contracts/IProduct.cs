namespace CalorieCounterEngine.Contracts
{
    public interface IProduct
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Weight of the product - in grams or milliliters.
        /// </summary>
        decimal Weight { get; }
        /// <summary>
        /// Approximate amount of energy in the product.
        /// </summary>
        int Calories { get; }
        /// <summary>
        /// Protein contained in the product.
        /// </summary>
        int Protein { get; }
        /// <summary>
        /// Carbohydrates contained in the product.
        /// </summary>
        int Carbs { get; }
        /// <summary>
        /// Fats contained in the product.
        /// </summary>
        int Fat { get; }
        /// <summary>
        /// Sugar contained in the product.
        /// </summary>
        int Sugar { get; }
        /// <summary>
        /// Name of the product.
        /// </summary>
        int Fiber { get; }
    }
}