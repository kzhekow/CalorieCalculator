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
    class CreateGoal : ICommand
    {
        private readonly IGoalFactory factory;
        private readonly ICommandParserEngine engine;

        public CreateGoal(IGoalFactory factory, ICommandParserEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {

        }
    }
}
