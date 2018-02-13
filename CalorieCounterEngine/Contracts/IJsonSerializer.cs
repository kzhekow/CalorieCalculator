using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;

namespace CalorieCounterEngine.Contracts
{
    public interface IJsonSerializer
    {
        IList<IProduct> GetProducts();
        IDailyIntake GetDailyIntake();
        void SaveDailyIntake(IDailyIntake dailyIntake);
        void SaveAllProducts(IDictionary<string, IProduct> products);
    }
}