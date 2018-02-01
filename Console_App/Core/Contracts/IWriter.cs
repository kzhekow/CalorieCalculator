namespace Console_App.Core.Contracts
{
    public interface IConsoleWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}