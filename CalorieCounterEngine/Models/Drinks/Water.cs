using System;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.Food
{
    public class Water : IWater
    {
        private const string DrinkName = "Water";

        public Water(decimal weightInMl)
        {
            if (weightInMl < 0)
            {
                throw new ArgumentException("Ml of water can not be a negative number!");
            }

            // Guard.WhenArgument(weightInMl, "Weight can not be a negative number!").IsLessThan(0).Throw();
            this.Weight = weightInMl;
        }

        public string Name => DrinkName;

        public decimal Weight { get; }
    }
}