using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using System.Collections.Generic;

namespace CalorieCounterEngine.Models.Contracts
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
