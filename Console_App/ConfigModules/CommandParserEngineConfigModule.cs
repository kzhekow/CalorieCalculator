using Autofac;
using CalorieCounter;
using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Factories.Contracts;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using Console_App.Core.Providers;

namespace Console_App.ConfigModules
{
    public class CommandParserEngineConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GoalFactory>().As<IGoalFactory>().SingleInstance();
            builder.RegisterType<ProductFactory>().As<IProductFactory>().SingleInstance();
            builder.RegisterType<ActivityFactory>().As<IActivityFactory>().SingleInstance();
            builder.RegisterType<CalorieCounterEngine>().As<ICalorieCounterEngine>().SingleInstance();

            builder.RegisterType<ConsoleReader>().As<IConsoleReader>();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>();
            builder.RegisterType<CommandParser>().As<IConsoleParser>();
            builder.RegisterType<CommandParserEngine>().As<ICommandParserEngine>();
        }
    }
}
