using CalorieCounter.Contracts;
using CalorieCounterEngine.Contracts;
using System;
using System.Collections.Generic;

namespace CalorieCounterEngine
{
    public class DataRepository : IDataRepository

    {
        public DataRepository()
        {
            this.Products = new Dictionary<string, IProduct>(StringComparer.InvariantCultureIgnoreCase);
        }

        public IDictionary<string, IProduct> Products { get; }
    }
}