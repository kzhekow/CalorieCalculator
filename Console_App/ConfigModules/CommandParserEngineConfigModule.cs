using Autofac;
using Console_App.Contracts;
using Console_App.Core.Commands.Adding;
using Console_App.Core.Commands.Creating;
using Console_App.Core.Commands.Showing;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using Console_App.Core.Providers;
using Console_App.Factories;

namespace Console_App.ConfigModules
{
    public class CommandParserEngineConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandParserEngine>().As<ICommandParserEngine>().SingleInstance();

            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<AddActivityCommand>().Named<ICommand>("addactivity");
            builder.RegisterType<AddConsumedProductCommand>().Named<ICommand>("addconsumedproduct");
            builder.RegisterType<CreateDrinkCommand>().Named<ICommand>("createdrink");
            builder.RegisterType<CreateFoodProductCommand>().Named<ICommand>("createfoodproduct");
            builder.RegisterType<SetGoalCommand>().Named<ICommand>("setgoal");
            builder.RegisterType<ShowAllProductsCommand>().Named<ICommand>("showallproducts");
            builder.RegisterType<ShowDailyReportCommand>().Named<ICommand>("showdailyreport");
            builder.RegisterType<ShowRemainingNutrientsCommand>().Named<ICommand>("showremainingnutrients");
        }
    }
}
