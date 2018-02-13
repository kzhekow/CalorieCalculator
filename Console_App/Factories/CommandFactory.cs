using Autofac;
using Console_App.Contracts;
using Console_App.Core.Contracts;

namespace Console_App.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand Create(string cmdName)
        {
            return this.container.ResolveNamed<ICommand>(cmdName);
        }
    }
}