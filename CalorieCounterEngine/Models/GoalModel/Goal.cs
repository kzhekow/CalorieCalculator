using System;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.GoalModel
{
    public class Goal : IGoal
    {
        public Goal(double startingWeight, double goalWeight, double height, int age, GenderType gender,
            GoalType goalType,
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
                throw new ArgumentException("The provided gender goalType is not valid!");
            }

            if (!Enum.IsDefined(typeof(GoalType), goalType))
            {
                throw new ArgumentException("The provided goal goalType is not valid!");
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
            this.GoalType = goalType;
            this.ActivityLevel = level;
        }

        public double StartingWeight { get; }

        public double GoalWeight { get; }

        public double Height { get; }

        public int Age { get; }

        public GenderType Gender { get; }

        public GoalType GoalType { get; }

        public ActivityLevel ActivityLevel { get; }
    }
}