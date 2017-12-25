using CalorieCounterEngine.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;

namespace CalorieCounterEngine.Models
{
    public abstract class Product : IProduct
    {
        /// <summary>
        /// Product name will be a string between 3 and 20 symbols.
        /// Product weight can not be a negative number.
        /// </summary>
        private readonly string name;
        private readonly decimal weight;
        
        /// <summary>
        /// Product constructor. Every Product must have a name and weight.
        /// </summary>
        public Product(string name, decimal weight)
        {
            Guard.WhenArgument(name, "Name can not be null!").IsNotNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Name must be between 3 and 20 symbols!").IsLessThan(3).IsGreaterThan(20).Throw();
            Guard.WhenArgument(weight, "Weight of the products can not be less or equal to zero!").IsLessThanOrEqual(0).Throw();

            this.name = name;
            this.weight = weight;
        }

        public string Name => this.name;

        public decimal Weight => this.weight;

        public static IProduct operator +(Product left, Product right)
        {
            // TODO: Custom meal instances should be created from a factory.
            var collection = new List<IProduct> { left, right };
            return new CustomMeal(collection);
        }
    }
}