using Autofac;
using Console_App.Contracts;
using Console_App.Core.Commands.Adding;
using Console_App.Core.Commands.Creating;
using Console_App.Core.Commands.Decorators;
using Console_App.Core.Commands.Showing;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using Console_App.Core.Providers;
using Console_App.Factories;
using System.Configuration;

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

            var isTestEnv = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<SetGoalCommand>().Named<ICommand>("setgoal").SingleInstance();
            builder.RegisterType<CreateDrinkCommand>().Named<ICommand>("createdrink").SingleInstance();
            builder.RegisterType<CreateFoodProductCommand>().Named<ICommand>("createfoodproduct").SingleInstance();
            builder.RegisterType<AddActivityCommand>().Named<ICommand>("addactivity").SingleInstance();
            builder.RegisterType<AddConsumedProductCommand>().Named<ICommand>("addconsumedproduct").SingleInstance();
            builder.RegisterType<AddWaterCommand>().Named<ICommand>("addwater").SingleInstance();

            if (isTestEnv)
            {
                builder.RegisterType<ShowAllProductsCommand>().Named<ICommand>("showallproductsTestEnv")
                    .SingleInstance();
                builder.RegisterType<ShowDailyReportCommand>().Named<ICommand>("showdailyreportTestEnv")
                    .SingleInstance();
                builder.RegisterType<ShowRemainingNutrientsCommand>().Named<ICommand>("showremainingnutrientsTestEnv")
                    .SingleInstance();

                builder.RegisterType<LoggerCommandDecorator>().Named<ICommand>("showallproducts")
                    .WithParameter(
                        (pi, ctx) => pi.Name == "command",
                        (pi, ctx) => ctx.ResolveNamed<ICommand>("showallproductsTestEnv")).SingleInstance();

                builder.RegisterType<LoggerCommandDecorator>().Named<ICommand>("showdailyreport")
                    .WithParameter(
                        (pi, ctx) => pi.Name == "command",
                        (pi, ctx) => ctx.ResolveNamed<ICommand>("showdailyreportTestEnv")).SingleInstance();

                builder.RegisterType<LoggerCommandDecorator>().Named<ICommand>("showremainingnutrients")
                    .WithParameter(
                        (pi, ctx) => pi.Name == "command",
                        (pi, ctx) => ctx.ResolveNamed<ICommand>("showremainingnutrientsTestEnv")).SingleInstance();
            }
            else
            {
                builder.RegisterType<ShowAllProductsCommand>().Named<ICommand>("showallproducts").SingleInstance();
                builder.RegisterType<ShowDailyReportCommand>().Named<ICommand>("showdailyreport").SingleInstance();
                builder.RegisterType<ShowRemainingNutrientsCommand>().Named<ICommand>("showremainingnutrients")
                    .SingleInstance();
            }
        }
    }
}