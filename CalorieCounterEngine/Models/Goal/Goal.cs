using System;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.Goal
{
    public class Goal : IGoal
    {
        public Goal(double startingWeight, double goalWeight, double height, int age, GenderType gender, GoalType type,
            ActivityLevel level)
        {
            if (startingWeight < 0)
            {
                throw new ArgumentException("Starting weight can not be a negative number!");
            }

            if (goalWeight < 0)
            {
                throw new ArgumentException("Goal weight can not be a negative number!");
            }

            if (height < 0)
            {
                throw new ArgumentException("Height can not be a negative number!");
            }

            if (age < 0)
            {
                throw new ArgumentException("Age can not be a negative number!");
            }

            if (!Enum.IsDefined(typeof(GenderType), gender))
            {
                throw new ArgumentException("The provided gender type is not valid!");
            }

            if (!Enum.IsDefined(typeof(GoalType), type))
            {
                throw new ArgumentException("The provided goal type is not valid!");
            }

            if (!Enum.IsDefined(typeof(ActivityLevel), level))
            {
                throw new ArgumentException("The provided activity level is not valid!");
            }

            //Guard.WhenArgument(startingWeight, "Starting weight can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(goalWeight, "Goal weight can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(height, "Height can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(age, "Age can not be a negative number!").IsLessThan(0).Throw();

            this.StartingWeight = startingWeight;
            this.GoalWeight = goalWeight;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
            this.Type = type;
            this.Level = level;
        }

        public double StartingWeight { get; }

        public double GoalWeight { get; }

        public double Height { get; }

        public int Age { get; }

        public GenderType Gender { get; }

        public GoalType Type { get; }

        public ActivityLevel Level { get; }

        public double CalculateRestingEnergy()
        {
            double bmr = 0;

            switch (this.Gender)
            {
                case GenderType.Male:
                    bmr = 10 * this.StartingWeight + 6.25 * this.Height - 5 * this.Age + 5;
                    break;
                case GenderType.Female:
                    bmr = 10 * this.StartingWeight + 6.25 * this.Height - 5 * this.Age - 161;
                    break;
                default:
                    break;
            }

            return bmr;
        }

        public double CalculateSuggestedDailyCalorieIntake()
        {
            var dailyCalorieIntake = this.CalculateRestingEnergy();

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
            var dailyWaterIntake = 0;

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

        public double CalculateSuggestedDailyCarbsIntake()
        {
            double suggestCarbsIntake = 0;

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestCarbsIntake = 0.25 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.MaintainWeight:
                    suggestCarbsIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.GainWeight:
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

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestProteinIntake = 0.4 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.MaintainWeight:
                    suggestProteinIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake() / 4;
                    break;
                case GoalType.GainWeight:
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

            switch (this.Type)
            {
                case GoalType.LoseWeight:
                    suggestFatIntake = 0.35 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                case GoalType.MaintainWeight:
                    suggestFatIntake = 0.3 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                case GoalType.GainWeight:
                    suggestFatIntake = 0.2 * this.CalculateSuggestedDailyCalorieIntake() / 9;
                    break;
                default:
                    break;
            }

            return suggestFatIntake;
        }
    }
}