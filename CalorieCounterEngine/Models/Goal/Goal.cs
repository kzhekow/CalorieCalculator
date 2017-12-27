using Bytes2you.Validation;
using CalorieCounterEngine.Models.Contracts;
using System;

namespace CalorieCounterEngine.Models.Goal
{
    public class Goal : IGoal
    {
        private readonly double startingWeight;
        private readonly double goalWeight;
        private readonly double height;
        private readonly GenderType gender;
        private readonly GoalType type;
        private readonly ActivityLevel level;

        public Goal(double startingWeight, double goalWeight, double height, GenderType gender, GoalType type, ActivityLevel level)
        {
            Guard.WhenArgument(startingWeight, "Starting weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(goalWeight, "Goal weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(height, "Height can not be a negative number!").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GenderType), gender))
                throw new ArgumentException("The provided gender type is not valid!");
            if (!Enum.IsDefined(typeof(GoalType), type))
                throw new ArgumentException("The provided goal type is not valid!");
            if (!Enum.IsDefined(typeof(ActivityLevel), level))
                throw new ArgumentException("The provided activity level is not valid!");

            this.startingWeight = startingWeight;
            this.goalWeight = goalWeight;
            this.height = height;
            this.gender = gender;
            this.type = type;
            this.level = level;
        }

        public double StartingWeight => this.startingWeight;

        public double GoalWeight => this.goalWeight;

        public double Height => this.height;

        public GenderType Gender => this.gender;

        public GoalType Type => this.type;

        public ActivityLevel Level => this.level;

        public double CalculateRestingEnergy()
        {
            double bmi = 0;

            switch (this.Gender)
            {
                case GenderType.Male: bmi = (11.936 * this.StartingWeight) + (586.728 * this.Height) + 191.027 + 29.279;
                    break;
                case GenderType.Female: bmi = (11.936 * this.StartingWeight) + (586.728 * this.Height) + 29.279;
                    break;
                default:
                    break;
            }
            return bmi;
        }

        public double CalculateSuggestedDailyCalorieIntake()
        {
            double dailyCalorieIntake = this.CalculateRestingEnergy();

            switch (this.Level)
            {
                case ActivityLevel.Light: dailyCalorieIntake *= 1.375;
                    break;
                case ActivityLevel.Moderate: dailyCalorieIntake *= 1.55;
                    break;
                case ActivityLevel.Heavy: dailyCalorieIntake *= 1.725;
                    break;
                default:
                    break;
            }
            return dailyCalorieIntake;
        }

        public string CalculateSuggestedMacrosRatio()
        {
            var macrosRatio = string.Empty;

            switch (this.Type)
            {
                case GoalType.LoseWeight: macrosRatio = "Carbs:Protein:Fat = 25:40:35";
                    break;
                case GoalType.MaintainWeight: macrosRatio = "Carbs:Protein:Fat = 40:30:30";
                    break;
                case GoalType.GainWeight: macrosRatio = "Carbs:Protein:Fat = 50:30:20";
                    break;
                default:
                    break;
            }
            return macrosRatio;
        }

        public int CalculateSuggestedWaterIntake()
        {
            int dailyWaterIntake = 0;

            switch (this.Gender)
            {
                case GenderType.Male: dailyWaterIntake = 3700;
                    break;
                case GenderType.Female: dailyWaterIntake = 2600;
                    break;
                default:
                    break;
            }
            return dailyWaterIntake;
        }
    }
}
