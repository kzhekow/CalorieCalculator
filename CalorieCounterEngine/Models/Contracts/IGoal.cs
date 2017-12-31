namespace CalorieCounter.Models.Contracts
{
    public interface IGoal
    {
        /// <summary>
        ///     This is the weight of the user, when the goal was initially set.
        /// </summary>
        double StartingWeight { get; }

        /// <summary>
        ///     This is the weight that the user is trying to reach.
        /// </summary>
        double GoalWeight { get; }

        /// <summary>
        ///     This is the height of the user in centimeters.
        /// </summary>
        double Height { get; }

        /// <summary>
        ///     This is the age of the user in kilograms.
        /// </summary>
        int Age { get; }

        /// <summary>
        ///     This is the gender of the user.
        /// </summary>
        GenderType Gender { get; }

        /// <summary>
        ///     Goals can be 3 types - lost weight, maintain weight and gain weight.
        /// </summary>
        GoalType Type { get; }

        /// <summary>
        ///     Activity can have 3 types: light, moderate, heavy.
        /// </summary>
        ActivityLevel Level { get; }

        /// <summary>
        ///     Calcultates the suggested macros ratio of the user, taking in mind his goal.
        /// </summary>
        /// <returns>
        ///     Returns a string - "Carbs:Protein:Fat 50:20:30".
        /// </returns>
        string CalculateSuggestedMacrosRatio();

        /// <summary>
        ///     Calculates the suggested daily calorie intake of the user, taking in mind his goal.
        /// </summary>
        /// <returns>
        ///     Returns integer of the number.
        /// </returns>
        double CalculateSuggestedDailyCalorieIntake();

        /// <summary>
        ///     Calculates the suggested daily water intake of the user.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        int CalculateSuggestedWaterIntake();

        /// <summary>
        ///     Calculates resting calories of the user - energy his body expends just to keep him alive.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateRestingEnergy();
    }
}