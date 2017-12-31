using System;
using Console_App.Core.Contracts;

namespace Console_App.Core.Providers
{
    internal class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}