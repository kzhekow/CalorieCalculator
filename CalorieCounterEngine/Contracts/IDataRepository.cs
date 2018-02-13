using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace CalorieCounterEngine.Contracts
{
    public interface IDataRepository
    {
        IDictionary<string, IProduct> Products { get; }
    }
}