using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Contracts;

namespace CalorieCounterEngine.Contracts
{
    public interface IDataRepository
    {
        IDictionary<string, IProduct> Products { get; }
    }
}
