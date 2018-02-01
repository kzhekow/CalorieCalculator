using System.Collections.Generic;

namespace Console_App.Core.Contracts
{
    public interface IConsoleParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}