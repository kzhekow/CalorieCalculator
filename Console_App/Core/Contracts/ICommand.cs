using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Core.Contracts
{
    interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
