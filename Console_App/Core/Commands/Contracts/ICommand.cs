using System.Collections.Generic;

namespace Console_App.Core.Contracts
{
    internal interface ICommand
    {
        string Execute(IList<string> parameters);


        //string Name { get; }

        //IList<string> Parameters { get; }
    }
}