using System;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.DrinksModel
{
    public struct Water : IWater
    {
        public Water(decimal weightInMl)
        {
            if (weightInMl < 0)
            {
                throw new ArgumentException("Ml of water can not be a negative number!");
            }

            // Guard.WhenArgument(weightInMl, "Weight can not be a negative number!").IsLessThan(0).Throw();
            this.Weight = weightInMl;
        }

        public decimal Weight { get; }
    }
}