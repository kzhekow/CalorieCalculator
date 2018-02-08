using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.GoalModel;

namespace CalorieCounter.Factories
{
    public class GoalFactory : IGoalFactory
    {
        public IGoal CreateGoal(double startingWeight, double goalWeight, double height, int age, GenderType gender,
            GoalType type, ActivityLevel level)
        {
            return new Goal(startingWeight, goalWeight, height, age, gender, type, level);
        }
    }
}