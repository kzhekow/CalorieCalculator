using CalorieCounter.Factories.Contracts;
using CalorieCounterEngine.Models.Contracts;
using CalorieCounterEngine.Models.Goal;

namespace CalorieCounterEngine.Factories
{
    public class GoalFactory : IGoalFactory
    {
        public static IGoalFactory instanceHolder = new GoalFactory();

        private GoalFactory()
        {

        }
        public static IGoalFactory Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new GoalFactory();
                }

                return instanceHolder;
            }
        }


        public IGoal CreateGoal(double startingWeight, double goalWeight, double height, int age, GenderType gender, GoalType type, ActivityLevel level)
        {
            return new Goal(startingWeight, goalWeight, height, age, gender, type, level);
        }
    }
}
