using System;
using CalorieCounterEngine.Models.Contracts;

namespace CalorieCounterEngine.Models.Food
{
    using Bytes2you.Validation;

    public class Water : IWater
    {
        private const string DrinkName = "Water";
        private readonly decimal weight;

        public Water(decimal weightInMl)
        {
            Guard.WhenArgument(weightInMl, "Weight can not be a negative number!").IsLessThan(0).Throw();
            this.weight = weightInMl;
        }

        public string Name => Water.DrinkName;

        public decimal Weight => this.weight;
    }
}
