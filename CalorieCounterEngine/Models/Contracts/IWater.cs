namespace CalorieCounter.Models.Contracts
{
    public interface IWater
    {
        /// <summary>
        ///     Name of the product.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Weight of the product - in grams or milliliters.
        /// </summary>
        decimal Weight { get; }
    }
}