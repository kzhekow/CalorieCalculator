using Bytes2you.Validation;
using CalorieCounterEngine.Models.Contracts;
using System;

namespace CalorieCounterEngine.Models.Activity
{
    public class Activity : IActivity
    {
        private readonly int time;
        private readonly ActivityType type;

        public Activity(int time, ActivityType type)
        {
            Guard.WhenArgument(time, "Time can not be a negative number!").IsLessThan(0);
            if (!Enum.IsDefined(typeof(ActivityType), type)) throw new ArgumentException("The provided activity type is not valid!");

            this.time = time;
            this.type = type;
        }
        public int Time => this.time;

        public ActivityType Type => this.type;

        public int CalculateBurnedCalories()
        {
            return (int)this.Type * (this.Time / 60);
        }
    }
}
