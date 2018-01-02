using System;

namespace CalorieCounter.CustomException
{
    public class CommandParseЕxception : Exception
    {
        public CommandParseЕxception()
        {
        }

        public CommandParseЕxception(string message)
            : base(message)
        {
        }

        public CommandParseЕxception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}