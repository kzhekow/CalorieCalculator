namespace Console_App.Core.Contracts
{
    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}