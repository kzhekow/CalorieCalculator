namespace CalorieCounter.Contracts
{
    public interface ISuggestedDailyNutrientsIntakeCalc
    {
        /// <summary>
        /// Stores suggested daily calorie intake
        /// </summary>
        double DailyCalorieIntake { get; }

        /// <summary>
        /// Stores resting energy value
        /// </summary>
        double RestingEnergy { get; }
       
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
        ///     Calculates Suggested daily protein intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyProteinIntake();

        /// <summary>
        ///     Calculates Suggested daily carbs intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyCarbsIntake();

        /// <summary>
        ///     Calculates Suggested daily fat intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyFatIntake();
    }
}
