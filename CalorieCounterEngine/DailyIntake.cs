using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;

namespace CalorieCounter.Models
{
    public class DailyIntake : IDailyIntake
    {
        public int Water { get; private set; }

        public ICollection<IProduct> ProductsConsumed { get; private set; } = new List<IProduct>();

        public ICollection<IActivity> ActivitiesPerformed { get; private set; } = new List<IActivity>();

        public IGoal Goal { get; set; }

        public void AddWater(int water)
        {
            if (water < 0)
            {
                throw new ArgumentException("Water can not be a negative number!");
            }

            //Guard.WhenArgument(water, "Water can not be a negative number!").IsLessThan(0).Throw();
            this.Water += water;
        }

        public void RemoveWater(int water)
        {
            if (water < 0)
            {
                throw new ArgumentException("Water can not be a negative number!");
            }

            //Guard.WhenArgument(water, "Water can not be a negative number!").IsLessThan(0).Throw();
            this.Water -= water;
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product can not be null!");
            }

            //Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            this.ProductsConsumed.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product can not be null!");
            }

            if (this.ProductsConsumed == null)
            {
                throw new ArgumentException("The list of products is empty!");
            }
            //Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            //Guard.WhenArgument(this.ProductsConsumed, "The list of products is empty!").IsNull().Throw();

            this.ProductsConsumed.Remove(product);
        }

        public void AddActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("Activity can not be null!");
            }

            //Guard.WhenArgument(activity, "Activity can not be null!").IsNull().Throw();
            this.ActivitiesPerformed.Add(activity);
        }

        public void RemoveActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentException("Activity can not be null!");
            }

            if (this.ActivitiesPerformed == null)
            {
                throw new ArgumentException("The list of activities is empty!");
            }
            //Guard.WhenArgument(activity, "Activity can not be null!").IsNull().Throw();
            //Guard.WhenArgument(this.ActivitiesPerformed, "The list of activities is empty!").IsNull().Throw();

            this.ActivitiesPerformed.Remove(activity);
        }
    }
}