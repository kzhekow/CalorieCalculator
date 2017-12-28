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
        private readonly int age;
        private readonly GenderType gender;
        private readonly GoalType type;
        private readonly ActivityLevel level;

        public Goal(double startingWeight, double goalWeight, double height, int age, GenderType gender, GoalType type, ActivityLevel level)
        {
            Guard.WhenArgument(startingWeight, "Starting weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(goalWeight, "Goal weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(height, "Height can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(age, "Age can not be a negative number!").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GenderType), gender))
                throw new ArgumentException("The provided gender type is not valid!");
            if (!Enum.IsDefined(typeof(GoalType), type))
                throw new ArgumentException("The provided goal type is not valid!");
            if (!Enum.IsDefined(typeof(ActivityLevel), level))
                throw new ArgumentException("The provided activity level is not valid!");

            this.startingWeight = startingWeight;
            this.goalWeight = goalWeight;
            this.height = height;
            this.age = age;
            this.gender = gender;
            this.type = type;
            this.level = level;
        }

        public double StartingWeight => this.startingWeight;

        public double GoalWeight => this.goalWeight;

        public double Height => this.height;

        public int Age => this.age;

        public GenderType Gender => this.gender;

        public GoalType Type => this.type;

        public ActivityLevel Level => this.level;

        public double CalculateRestingEnergy()
        {
            double bmr = 0;

            switch (this.Gender)
            {
                case GenderType.Male:
                    bmr = (10 * this.StartingWeight) + (6.25 * this.Height) - (5 * this.Age) + 5;
                    break;
                case GenderType.Female:
                    bmr = (10 * this.StartingWeight) + (6.25 * this.Height) - (5 * this.Age) - 161;
                    break;
                default:
                    break;
            }
            return bmr;
        }

        public double CalculateSuggestedDailyCalorieIntake()
        {
            double dailyCalorieIntake = this.CalculateRestingEnergy();

            switch (this.Level)
            {
                case ActivityLevel.Light:
                    dailyCalorieIntake *= 1.375;
                    break;
                case ActivityLevel.Moderate:
                    dailyCalorieIntake *= 1.55;
                    break;
                case ActivityLevel.Heavy:
                    dailyCalorieIntake *= 1.725;
                    break;
                default:
                    break;
            }
            return dailyCalorieIntake;
        }

        public double CalculateSuggestedDailyCarbsIntake()
        {
            double suggestCarbsIntake = 0;

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestCarbsIntake = (0.25 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                case GoalType.MaintainWeight:
                    suggestCarbsIntake = (0.4 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                case GoalType.GainWeight:
                    suggestCarbsIntake = (0.5 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                default:
                    break;
            }
            return suggestCarbsIntake;
        }

        public double CalculateSuggestedDailyProteinIntake()
        {
            double suggestProteinIntake = 0;

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestProteinIntake = (0.4 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                case GoalType.MaintainWeight:
                    suggestProteinIntake = (0.3 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                case GoalType.GainWeight:
                    suggestProteinIntake = (0.3 * CalculateSuggestedDailyCalorieIntake() / 4);
                    break;
                default:
                    break;
            }
            return suggestProteinIntake;
        }

        public double CalculateSuggestedDailyFatIntake()
        {
            double suggestFatIntake = 0;

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestFatIntake = (0.35 * CalculateSuggestedDailyCalorieIntake() / 9);
                    break;
                case GoalType.MaintainWeight:
                    suggestFatIntake = (0.3 * CalculateSuggestedDailyCalorieIntake() / 9);
                    break;
                case GoalType.GainWeight:
                    suggestFatIntake = (0.2 * CalculateSuggestedDailyCalorieIntake() / 9);
                    break;
                default:
                    break;
            }
            return suggestFatIntake;
        }

        public string CalculateSuggestedMacrosRatio()
        {
            var macrosRatio = string.Empty;

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    macrosRatio = "Carbs:Protein:Fat = 25:40:35";
                    break;
                case GoalType.MaintainWeight:
                    macrosRatio = "Carbs:Protein:Fat = 40:30:30";
                    break;
                case GoalType.GainWeight:
                    macrosRatio = "Carbs:Protein:Fat = 50:30:20";
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
                case GenderType.Male:
                    dailyWaterIntake = 3700;
                    break;
                case GenderType.Female:
                    dailyWaterIntake = 2600;
                    break;
                default:
                    break;
            }
            return dailyWaterIntake;
        }
    }
}
