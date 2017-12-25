using System;
using CalorieCounterEngine.Models.Contracts;

namespace CalorieCounterEngine.Models.Food
{
    public class Water : IWater
    {
        private const string DrinkName = "Water";
        private readonly decimal weight;

        public Water(decimal weightInMl)
        {
            if (weightInMl < 0) throw new ArgumentException("Weight can not be a negative number!");
            this.weight = weightInMl;
        }

        public string Name => Water.DrinkName;

        public decimal Weight => this.weight;
    }
}
