﻿using Console_App.Core.Engine;

namespace Console_App
{
    internal class EntryPoint
    {
        private static void Main(string[] args)
        {
            var engine = CommandParserEngine.Instance;
            engine.Start();
        }
    }
}