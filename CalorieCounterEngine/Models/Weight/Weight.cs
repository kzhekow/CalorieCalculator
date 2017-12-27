using Bytes2you.Validation;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models.Weight
{
    /// <summary>
    ///     This class stores the individual body weight.
    /// </summary>
    public class Weight : IWeight
    {
        private readonly decimal weight;

        public Weight(decimal weight)
        {
            Guard.WhenArgument(weight, "Weight can not be a negative nubmer!").IsLessThan(0).Throw();
            this.weight = weight;
        }

        decimal IWeight.Weight => this.weight;
    }
}