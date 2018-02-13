using CalorieCounter.Models.Contracts;
using CalorieCounter.Contracts;
using Bytes2you.Validation;
using CalorieCounterEngine.Contracts;

namespace CalorieCounter.Utils
{
    public class SuggestedDailyNutrientsIntakeCalc : ISuggestedDailyNutrientsIntakeCalc
    {
        public double DailyCalorieIntake { get; private set; }

        public double CalculateSuggestedDailyCalorieIntake(IGoal goal, IRestingEnergyCalculator restingEnergyCalculator)
        {
            var RestingEnergy = restingEnergyCalculator.CalculateRestingEnergy(goal);
            switch (goal.ActivityLevel)
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
             
            }

            return this.DailyCalorieIntake;
        }

        public string CalculateSuggestedMacrosRatio(IGoal currentGoal)
        {
            var macrosRatio = string.Empty;

            switch (currentGoal.GoalType)
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
            
            }

            return macrosRatio;
        }

        public int CalculateSuggestedWaterIntake(IGoal currentGoal)
        {
            var dailyWaterIntake = 0;

            switch (currentGoal.Gender)
            {
                case GenderType.male:
                    dailyWaterIntake = 3700;
                    break;
                case GenderType.female:
                    dailyWaterIntake = 2600;
                    break;
           
            }

            return dailyWaterIntake;
        }

        public double CalculateSuggestedDailyCarbsIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator)
        {
            double suggestCarbsIntake = 0;

            switch (currentGoal.GoalType)
            {
                case GoalType.loseweight:
                    suggestCarbsIntake = 0.25 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
                case GoalType.maintainweight:
                    suggestCarbsIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
                case GoalType.gainweight:
                    suggestCarbsIntake = 0.5 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
           
            }

            return suggestCarbsIntake;
        }

        public double CalculateSuggestedDailyProteinIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator)
        {
            double suggestProteinIntake = 0;

            switch (currentGoal.GoalType)
            {
                case GoalType.loseweight:
                    suggestProteinIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
                case GoalType.maintainweight:
                    suggestProteinIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
                case GoalType.gainweight:
                    suggestProteinIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 4;
                    break;
               
            }

            return suggestProteinIntake;
        }

        public double CalculateSuggestedDailyFatIntake(IGoal currentGoal, IRestingEnergyCalculator restingEnergyCalculator)
        {
            double suggestFatIntake = 0;

            switch (currentGoal.GoalType)
            {
                case GoalType.loseweight:
                    suggestFatIntake =(int) (0.35 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 9);
                    break;
                case GoalType.maintainweight:
                    suggestFatIntake =(int)( 0.3 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 9);
                    break;
                case GoalType.gainweight:
                    suggestFatIntake = (int)(0.2 * this.CalculateSuggestedDailyCalorieIntake(currentGoal, restingEnergyCalculator) / 9);
                    break;
          
            }

            return suggestFatIntake;
        }
    }
}
