//using System;
//using System.Collections.Generic;
//using Bytes2you.Validation;
//using Console_App.Core.Contracts;

//namespace Console_App.Core.Command
//{
//    public class Command : ICommand
//    {
//        private const char SplitCommandSymbol = ' ';
//        private string name;
//        private IList<string> parameters;

//        private Command(string input)
//        {
//            TransalteInput(input);
//        }

//        public string Name
//        {
//            get => this.name;
//            private set
//            {
//                Guard.WhenArgument(value, "Name cannot be null or empty.").IsNullOrEmpty().Throw();

//                this.name = value;
//            }
//        }

//        public IList<string> Parameters
//        {
//            get => this.parameters;
//            private set
//            {
//                Guard.WhenArgument(value, "List of strings cannot be null.").IsNull().Throw();
//                this.parameters = value;
//            }
//        }

//        public void TransalteInput(string input)
//        {
//            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

//            if (indexOfFirstSeparator < 0)
//            {
//                this.Name = input;
//                return;
//            }

//            this.Name = input.Substring(0, indexOfFirstSeparator);
//            this.Parameters = input.Substring(indexOfFirstSeparator + 1)
//                .Split(new[] {SplitCommandSymbol}, StringSplitOptions.RemoveEmptyEntries);
//        }

//        public static Command Parse(string input)
//        {
//            return new Command(input);
//        }
//    }
//}

