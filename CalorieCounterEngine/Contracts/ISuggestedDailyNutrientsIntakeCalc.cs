using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;

namespace CalorieCounter.Contracts
{
    public interface ISuggestedDailyNutrientsIntakeCalc
    {
        /// <summary>
        /// Stores suggested daily calorie intake
        /// </summary>
        double DailyCalorieIntake { get; }
       
        /// <summary>
        ///     Calcultates the suggested macros ratio of the user, taking in mind his goal.
        /// </summary>
        /// <returns>
        ///     Returns a string - "Carbs:Protein:Fat 50:20:30".
        /// </returns>
        string CalculateSuggestedMacrosRatio(IGoal currentGoal);

        /// <summary>
        ///     Calculates the suggested daily calorie intake of the user, taking in mind his goal.
        /// </summary>
        /// <returns>
        ///     Returns integer of the number.
        /// </returns>
        double CalculateSuggestedDailyCalorieIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator);

        /// <summary>
        ///     Calculates the suggested daily water intake of the user.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        int CalculateSuggestedWaterIntake(IGoal currentGoal);

        /// <summary>
        ///     Calculates Suggested daily protein intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyProteinIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator);

        /// <summary>
        ///     Calculates Suggested daily carbs intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyCarbsIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator);

        /// <summary>
        ///     Calculates Suggested daily fat intake.
        /// </summary>
        /// <returns>
        ///     Returns a double of the number.
        /// </returns>
        double CalculateSuggestedDailyFatIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator);
    }
}
