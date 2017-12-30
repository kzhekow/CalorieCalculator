using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_App.Core.Contracts;

namespace Console_App.Core.Engine
{
    public class CommandParserEngine :ICommandParserEngine
    {
        private static CommandParserEngine instanceHolder;

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        public static CommandParserEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new CommandParserEngine();
                }

                return instanceHolder;
            }
        }

        public IReader Reader { get ; set ; }
        public IWriter Writer { get ; set ; }
        public IParser Parser { get; set ; }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
