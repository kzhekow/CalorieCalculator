using CalorieCounter.Factories.Contracts;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Commands.Creating
{
    public abstract class CreateProductCommand : ICommand
    {
        private readonly IProductFactory factory;
        private readonly ICommandParserEngine engine;

        public CreateProductCommand(IProductFactory factory, ICommandParserEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public IProductFactory Factory => factory;

        public ICommandParserEngine Engine => engine;

        public abstract string Execute(IList<string> parameters);
    }
}
