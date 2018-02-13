using System;
using System.Collections.Generic;
using Console_App.Core.Contracts;

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
            this.writer.WriteLine($"Report for {DateTime.Now.Date.ToShortDateString()}");
            return this.command.Execute(parameters);
        }
    }
}