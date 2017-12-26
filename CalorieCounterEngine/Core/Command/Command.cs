using CalorieCounterEngine.Core.Contracts;
using System;
using System.Collections.Generic;
using Bytes2you.Validation;


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
            private set
            {
                Guard.WhenArgument(value, "Name cannot be null or empty.").IsNullOrEmpty().Throw();

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
                Guard.WhenArgument(value, "List of strings cannot be null.").IsNull().Throw();
                this.parameters = value;
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
