using CalorieCounter.Models.Contracts;
using CalorieCounter.Contracts;
using Bytes2you.Validation;
using CalorieCounterEngine.Contracts;

namespace CalorieCounter.Utils
{
    public class SuggestedDailyNutrientsIntakeCalc : ISuggestedDailyNutrientsIntakeCalc
    {
        private IGoal currentGoal;
        private readonly IRestingEnergy restingEnergy;

        public SuggestedDailyNutrientsIntakeCalc(IGoal currentGoal, IRestingEnergy restingEnergy)
        {
            Guard.WhenArgument(currentGoal, "Goal").IsNull().Throw();
            Guard.WhenArgument(restingEnergy, "RestingEnergy").IsNull().Throw();

            this.currentGoal = currentGoal;
            this.restingEnergy = restingEnergy;
        }
        public double DailyCalorieIntake { get; private set; }

        public double RestingEnergy => this.restingEnergy.CalculateRestingEnergy();

        public double CalculateSuggestedDailyCalorieIntake()
        {
            switch (this.currentGoal.Level)
            {
                case ActivityLevel.light:
                    this.DailyCalorieIntake = RestingEnergy * 1.375;
                    break;
                case ActivityLevel.moderate:
                    this.DailyCalorieIntake = RestingEnergy * 1.55;
                    break;
                case ActivityLevel.heavy:
                    this.DailyCalorieIntake = RestingEnergy * 1.725;
                    break;
                default:
                    break;
            }

            return this.DailyCalorieIntake;
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
