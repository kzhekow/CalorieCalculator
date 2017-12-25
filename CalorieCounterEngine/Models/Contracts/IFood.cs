namespace CalorieCounterEngine.Contracts
{
    interface IFood
    {
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
    }
}
