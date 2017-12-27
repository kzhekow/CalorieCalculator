namespace CalorieCounter.Models.Contracts
{
    public interface IActivity
    {
        /// <summary>
        ///     Type of physical activity.
        /// </summary>
        ActivityType Type { get; }

        /// <summary>
        ///     Tracks time of physical activity in minutes.
        /// </summary>
        int Time { get; }

        /// <summary>
        ///     Calculates burned calories during a workout.
        /// </summary>
        /// <returns>
        ///     Returns the calories burned during a workout.
        /// </returns>
        int CalculateBurnedCalories();
    }
}