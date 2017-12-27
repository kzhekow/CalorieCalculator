using Bytes2you.Validation;
using CalorieCounterEngine.Models.Contracts;
using System;

namespace CalorieCounterEngine.Models.Goal
{
    public class Goal : IGoal
    {
        private readonly double startingWeight;
        private readonly double goalWeight;
        private readonly GoalType type;

        public Goal(double startingWeight, double goalWeight, GoalType type)
        {
            Guard.WhenArgument(startingWeight, "Starting weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(goalWeight, "Goal weight can not be a negative number!").IsLessThan(0).Throw();
            if (!Enum.IsDefined(typeof(GoalType), type))
                throw new ArgumentException("The provided goal type is not valid!");

            this.startingWeight = startingWeight;
            this.goalWeight = goalWeight;
            this.type = type;
        }

        public double StartingWeight => this.startingWeight;

        public double GoalWeight => this.goalWeight;

        public GoalType Type => this.type;

        public int CalculateRestingEnergy()
        {
            throw new NotImplementedException();
        }

        public int CalculateSuggestedDailyCalorieIntake()
        {
            throw new NotImplementedException();
        }

        public string CalculateSuggestedMacrosRatio()
        {
            throw new NotImplementedException();
        }

        public int CalculateSuggestedWaterIntake()
        {
            throw new NotImplementedException();
        }
    }
}
