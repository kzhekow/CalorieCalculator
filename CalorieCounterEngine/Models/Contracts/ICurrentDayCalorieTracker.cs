using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models.Contracts
{
    public interface ICurrentDayCalorieTracker
    {
        int Water { get; }
        ICollection<IProduct> ProductsConsumed { get; }
        ICollection<IActivity> ActivitiesPerformed { get; }
        void AddWater(int water);
        void RemoveWater(int water);
        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
        void AddActivity(IActivity activity);
        void RemoveActivity(IActivity activity);
    }
}