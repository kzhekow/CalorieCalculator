using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Contracts
{
    abstract class IDrink : IProduct
    {
        public IDrink()
        {

        }
        public string Name => throw new NotImplementedException();

        public decimal Weight => throw new NotImplementedException();
    }
}
