using Console_App.Core.Contracts;

namespace Console_App.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string cmdName);
    }
}
