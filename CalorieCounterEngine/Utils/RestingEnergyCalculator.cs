using Bytes2you.Validation;
using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Utils
{
    public class RestingEnergyCalculator : IRestingEnergyCalculator
    {
        // Using Mifflin – St Jeor Formula
        public double CalculateRestingEnergy(IGoal currentGoal)
        {
            Guard.WhenArgument(currentGoal, "Goal").IsNull().Throw();

            double bmr = 0;

            switch (currentGoal.Gender)
            {
                case GenderType.male:
                    bmr = 10 * currentGoal.StartingWeight + 6.25 * currentGoal.Height - 5 * currentGoal.Age + 5;
                    break;
                case GenderType.female:
                    bmr = 10 * currentGoal.StartingWeight + 6.25 * currentGoal.Height - 5 * currentGoal.Age - 161;
                    break;
            }

            return bmr;
        }
    }
}