using Bytes2you.Validation;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.Food
{
    public class Water : IWater
    {
        private const string DrinkName = "Water";

        public Water(decimal weightInMl)
        {
            Guard.WhenArgument(weightInMl, "Weight can not be a negative number!").IsLessThan(0).Throw();
            this.Weight = weightInMl;
        }

        public string Name => DrinkName;

        public decimal Weight { get; }
    }
}