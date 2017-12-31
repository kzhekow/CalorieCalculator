using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    public interface ICommandParserEngine
    {
        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }
        void Start();
    }
}