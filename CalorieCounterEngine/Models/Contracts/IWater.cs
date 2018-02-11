namespace CalorieCounter.Models.Contracts
{
    public interface IWater
    {
        /// <summary>
        ///     Weight of the product - in grams or milliliters.
        /// </summary>
        decimal Weight { get; }
    }
}