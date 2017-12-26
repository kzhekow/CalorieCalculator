using Bytes2you.Validation;
using CalorieCounterEngine.Models.Contracts;

namespace CalorieCounterEngine.Models.Weight
{
    /// <summary>
    /// This class stores the individual body weight.
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
