using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Factories.Contracts
{
    public interface IActivityFactory
    {
        IActivity CreateActivity(int time, ActivityType type);
    }
}