using Console_App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Engine
{
    public interface ICommandParserEngine
    {
        void Start();

        IReader Reader { get; set; }

        IWriter Writer { get; set; }

        IParser Parser { get; set; }
    }
}
