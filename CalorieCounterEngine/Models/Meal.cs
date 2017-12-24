namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
    using CalorieCounterEngine.Contracts;

    public abstract class Meal : Product, IMeal, IProduct
    {
        protected Meal(ICollection<IProduct> products)
        {
            // TODO: Validations
            this.Products = products;
        }

        public ICollection<IProduct> Products { get; }
    }
}