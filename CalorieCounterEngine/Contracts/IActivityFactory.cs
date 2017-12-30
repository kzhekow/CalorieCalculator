using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Contracts
{
    public interface IActivityFactory
    {
        IActivity CreateActivity(int time, ActivityType type);
    }
}
