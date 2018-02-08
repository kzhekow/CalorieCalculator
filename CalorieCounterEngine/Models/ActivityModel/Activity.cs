using CalorieCounter.Models.Contracts;
using System;

namespace CalorieCounter.Models.ActivityModel
{
    public class Activity : IActivity
    {
        public Activity(int time, ActivityType type)
        {
            if (time < 0)
            {
                throw new ArgumentException("Time can not be a negative number!");
            }

            //Guard.WhenArgument(time, "Time can not be a negative number!").IsLessThan(0);
            if (!Enum.IsDefined(typeof(ActivityType), type))
            {
                throw new ArgumentException("The provided activity type is not valid!");
            }

            this.Time = time;
            this.Type = type;
        }

        public int Time { get; }

        public ActivityType Type { get; }

        public int CalculateBurnedCalories()
        {
            return (int)((int)this.Type * (this.Time / 60.0));
        }
    }
}