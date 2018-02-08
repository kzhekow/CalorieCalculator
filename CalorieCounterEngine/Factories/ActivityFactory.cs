using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.ActivityModel;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Factories
{
    public class ActivityFactory : IActivityFactory
    {
        public IActivity CreateActivity(int time, ActivityType type)
        {
            return new Activity(time, type);
        }
    }
}