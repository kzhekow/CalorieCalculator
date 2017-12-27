using System.Collections.Generic;

namespace Console_App.Core.Contracts
{
    internal interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}