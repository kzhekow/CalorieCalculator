using Console_App.Core.Contracts;
using System.Collections.Generic;

namespace Console_App.Core.Commands.Decorators
{
    public class LoggerCommandDecorator : ICommand
    {
        private readonly ICommand command;
        private readonly IConsoleWriter writer;

        public LoggerCommandDecorator(ICommand command, IConsoleWriter writer)
        {
            this.command = command;
            this.writer = writer;
        }

        public string Execute(IList<string> parameters)
        {
            writer.WriteLine("DECORATOR: We currently are in Test Environment!");
            return this.command.Execute(parameters);
        }
    }
}
