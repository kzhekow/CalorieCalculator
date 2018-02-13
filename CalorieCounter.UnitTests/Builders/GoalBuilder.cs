using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.GoalModel;

namespace CalorieCounter.UnitTests.Builders
{
    internal class GoalBuilder
    {
        private ActivityLevel activityLevel;
        private int age;
        private GenderType genderType;
        private GoalType goalType;
        private double goalWeight;
        private double height;
        private double startingWeight;

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
            return new Goal(this.startingWeight, this.goalWeight, this.height, this.age, this.genderType, this.goalType,
                this.activityLevel);
        }
    }
}