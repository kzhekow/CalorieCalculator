using CalorieCounterEngine.Models.Contracts;

namespace CalorieCounterEngine.Contracts
{
    public interface IGoalFactory
    {
        IGoal CreateGoal(double startingWeight, double goalWeight, double height, int age, GenderType gender, GoalType type, ActivityLevel level);
    }
}
