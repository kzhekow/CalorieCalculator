using CalorieCounter.Models.Contracts;

namespace CalorieCounterEngine.Contracts
{
    public interface IRestingEnergyCalculator
    {
        double CalculateRestingEnergy(IGoal goal);
    }
}