using System;
using Console_App.Core.Contracts;

namespace Console_App.Core.Providers
{
    internal class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}