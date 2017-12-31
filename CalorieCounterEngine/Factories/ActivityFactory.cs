using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Activity;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Factories
{
    public class ActivityFactory : IActivityFactory
    {
        private static IActivityFactory instanceHolder = new ActivityFactory();

        public static IActivityFactory Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new ActivityFactory();
                }

                return instanceHolder;
            }
        }

        public IActivity CreateActivity(int time, ActivityType type)
        {
            return new Activity(time, type);
        }
    }
}