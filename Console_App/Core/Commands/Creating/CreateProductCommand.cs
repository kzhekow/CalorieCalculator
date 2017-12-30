using CalorieCounter.Factories.Contracts;
using Console_App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Commands.Creating
{
    class CreateProductCommand : ICommand
    {
        private readonly IProductFactory factory;
        private readonly IEngine engine;

        public string Execute(IList<string> parameters)
        {

        }
    }
}
