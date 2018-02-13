﻿using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using System.Collections.Generic;

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
