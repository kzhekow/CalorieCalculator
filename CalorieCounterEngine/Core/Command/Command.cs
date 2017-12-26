using CalorieCounterEngine.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Core.Command
{
    class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';
        private string name;
        private IList<string> parameters;

        private Command(string input)
        {
            this.TransalteInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                { throw new ArgumentNullException("Command name cannot be null or empty."); }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }
            private set
            {
                this.parameters = value ?? throw new ArgumentNullException("List of strings cannot be null.");
            }
        }

        public void TransalteInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            if (indexOfFirstSeparator <0)
            {
                this.Name = input;
                return;
            }

            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }



        
    }
}
