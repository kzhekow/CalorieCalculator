using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.GoalModel;
using CalorieCounterEngine.Contracts;
using Moq;

namespace CalorieCounter.UnitTests.Builders
{
    internal class GoalBuilder
    {
        private double startingWeight;
        private double goalWeight;
        private double height;
        private int age;
        private GenderType genderType;
        private GoalType goalType;
        private ActivityLevel activityLevel;

        internal GoalBuilder()
        {
            this.startingWeight = 82;
            this.goalWeight = 78;
            this.height = 177;
            this.age = 25;
            this.genderType = GenderType.male;
            this.goalType = GoalType.loseweight;
            this.activityLevel = ActivityLevel.heavy;
        }

        internal GoalBuilder WithStartingWeight(double startingWeight)
        {
            this.startingWeight = startingWeight;
            return this;
        }

        internal GoalBuilder WithGoalWeight(double goalWeight)
        {
            this.goalWeight = goalWeight;
            return this;
        }

        internal GoalBuilder WithHeight(double height)
        {
            this.height = height;
            return this;
        }

        internal GoalBuilder WithAge(int age)
        {
            this.age = age;
            return this;
        }

        internal GoalBuilder WithGenderType(GenderType genderType)
        {
            this.genderType = genderType;
            return this;
        }

        internal GoalBuilder WithGoalType(GoalType goalType)
        {
            this.goalType = goalType;
            return this;
        }

        internal GoalBuilder WithActivityLevel(ActivityLevel activityLevel)
        {
            this.activityLevel = activityLevel;
            return this;
        }

        internal IGoal Build()
        {
            return new Goal(this.startingWeight, this.goalWeight, this.height, this.age, this.genderType, this.goalType, this.activityLevel);
        }
    }
}
