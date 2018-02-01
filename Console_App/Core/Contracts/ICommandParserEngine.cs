using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    public interface ICommandParserEngine
    {
        IConsoleReader Reader { get; set; }

        IConsoleWriter Writer { get; set; }

        IConsoleParser Parser { get; set; }
        void Start();
    }
}