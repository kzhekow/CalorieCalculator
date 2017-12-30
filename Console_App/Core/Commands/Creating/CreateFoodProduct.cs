using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Factories.Contracts;
using Console_App.Core.Engine;

namespace Console_App.Core.Commands.Creating
{
    class CreateFoodProduct : CreateProductCommand
    {
        public CreateFoodProduct(IProductFactory factory, ICommandParserEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
