using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Contracts
{
    abstract class IDrink : IProduct
    {
        private readonly string name;
        private readonly decimal weight;

        public IDrink(string name, decimal weight)
        {

            this.name = name;
            this.weight = weight;
        }

        public string Name => throw new NotImplementedException();

        public decimal Weight => throw new NotImplementedException();
    }
}
