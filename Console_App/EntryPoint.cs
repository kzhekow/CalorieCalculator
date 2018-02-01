using Autofac;
using CalorieCounter;
using CalorieCounter.Contracts;
using Console_App.ConfigModules;
using Console_App.Core.Engine;

namespace Console_App
{
    internal class EntryPoint
    {
        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
           // builder.RegisterModule<CalorieCounterEngineConfigModule>();
            builder.RegisterModule<CommandParserEngineConfigModule>();

            var container = builder.Build();
            var calorieCounterEngine = container.Resolve<ICalorieCounterEngine>();
            var commandParserEngine = container.Resolve<ICommandParserEngine>();

            commandParserEngine.Start();
        }
    }
}