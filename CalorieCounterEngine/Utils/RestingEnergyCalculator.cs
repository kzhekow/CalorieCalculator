using Bytes2you.Validation;
using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Utils
{
    public class RestingEnergyCalculator : IRestingEnergyCalculator
    {
        private readonly IGoal currentGoal;

        public RestingEnergyCalculator(IGoal currentGoal)
        {
            Guard.WhenArgument(currentGoal, "Goal").IsNull().Throw();
            this.currentGoal = currentGoal;
        }

        // Using Mifflin – St Jeor Formula
        public double CalculateRestingEnergy()
        {
            double bmr = 0;

            switch (this.currentGoal.Gender)
            {
                case GenderType.male:
                    bmr = 10 * this.currentGoal.StartingWeight + 6.25 * this.currentGoal.Height - 5 * this.currentGoal.Age + 5;
                    break;
                case GenderType.female:
                    bmr = 10 * this.currentGoal.StartingWeight + 6.25 * this.currentGoal.Height - 5 * this.currentGoal.Age - 161;
                    break;
                default:
                    break;
            }

            return bmr;
        }
    }
}
