using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Contracts
{
   public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
