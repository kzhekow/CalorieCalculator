using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Contracts;
using CalorieCounterEngine.Contracts;

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
