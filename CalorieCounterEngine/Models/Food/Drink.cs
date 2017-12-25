using Bytes2you.Validation;
using CalorieCounterEngine.Contracts;
using System;

namespace CalorieCounterEngine.Models.Food
{
    abstract class Drink : IDrink
    {
        private readonly string name;
        private readonly decimal weight;

        public Drink(string name, decimal weight)
        {
            Guard.WhenArgument(name, "Name can not be null!").IsNotNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Name must contain at least 3 symbols!").IsLessThan(3).Throw();
            Guard.WhenArgument(weight, "Weight of the products can not be less or equal to zero!").IsLessThanOrEqual(0).Throw();

            this.name = name;
            this.weight = weight;
        }

        public string Name => throw new NotImplementedException();

        public decimal Weight => throw new NotImplementedException();
    }
}
