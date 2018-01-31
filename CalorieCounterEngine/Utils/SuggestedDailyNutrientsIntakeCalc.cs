using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Utils
{
    public class SuggestedDailyNutrientsIntakeCalc : ISuggestedDailyNutrientsIntakeCalc
    {
        private IGoal currentGoal;

        public SuggestedDailyNutrientsIntakeCalc(IGoal currentGoal)
        {
            this.currentGoal = currentGoal;
        }

        public double CalculateRestingEnergy()
        {
            double bmr = 0;

            switch (this.currentGoal.Gender)
            {
                case GenderType.male:
                    bmr = 10 * this.currentGoal.StartingWeight + 6.25 * this.currentGoal.Height - 5 * this.currentGoal.Age + 5;
                    break;
                case GenderType.female:
                    bmr = 10 * this.currentGoal.StartingWeight + 6.25 * this.currentGoal.Height - 5 * this.currentGoal.Age - 161;
                    break;
                default:
                    break;
            }

            return bmr;
        }

        public double CalculateSuggestedDailyCalorieIntake()
        {
            var dailyCalorieIntake = this.CalculateRestingEnergy();

            switch (this.currentGoal.Level)
            {
                case ActivityLevel.light:
                    dailyCalorieIntake *= 1.375;
                    break;
                case ActivityLevel.moderate:
                    dailyCalorieIntake *= 1.55;
                    break;
                case ActivityLevel.heavy:
                    dailyCalorieIntake *= 1.725;
                    break;
                default:
                    break;
            }

            return dailyCalorieIntake;
        }

        public string CalculateSuggestedMacrosRatio()
        {
            var macrosRatio = string.Empty;

            switch (this.currentGoal.Type)
            {
                case GoalType.loseweight:
                    macrosRatio = "Carbs:Protein:Fat = 25:40:35";
                    break;
                case GoalType.maintainweight:
                    macrosRatio = "Carbs:Protein:Fat = 40:30:30";
                    break;
                case GoalType.gainweight:
                    macrosRatio = "Carbs:Protein:Fat = 50:30:20";
                    break;
                default:
                    break;
            }

            return macrosRatio;
        }

        public int CalculateSuggestedWaterIntake()
        {
            var dailyWaterIntake = 0;

            switch (this.currentGoal.Gender)
            {
                case GenderType.male:
                    dailyWaterIntake = 3700;
                    break;
                case GenderType.female:
                    dailyWaterIntake = 2600;
                    break;
                default:
                    break;
            }

            return dailyWaterIntake;
        }

        public double CalculateSuggestedDailyCarbsIntake()
        {
            double suggestCarbsIntake = 0;

            switch (this.currentGoal.Type)
            {
                case GoalType.loseweight:
                    suggestCarbsIntake = 0.25 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.maintainweight:
                    suggestCarbsIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.gainweight:
                    suggestCarbsIntake = 0.5 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                default:
                    break;
            }

            return suggestCarbsIntake;
        }

        public double CalculateSuggestedDailyProteinIntake()
        {
            double suggestProteinIntake = 0;

            switch (this.currentGoal.Type)
            {
                case GoalType.loseweight:
                    suggestProteinIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.maintainweight:
                    suggestProteinIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.gainweight:
                    suggestProteinIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                default:
                    break;
            }

            return suggestProteinIntake;
        }

        public double CalculateSuggestedDailyFatIntake()
        {
            double suggestFatIntake = 0;

            switch (this.currentGoal.Type)
            {
                case GoalType.loseweight:
                    suggestFatIntake = 0.35 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                case GoalType.maintainweight:
                    suggestFatIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                case GoalType.gainweight:
                    suggestFatIntake = 0.2 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                default:
                    break;
            }

            return suggestFatIntake;
        }
    }
}
