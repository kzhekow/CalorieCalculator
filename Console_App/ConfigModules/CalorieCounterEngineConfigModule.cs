using Autofac;
using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Factories.Contracts;
using CalorieCounter;
using CalorieCounter.Models.Utils;
using CalorieCounter.Utils;
using CalorieCounterEngine;
using CalorieCounterEngine.Contracts;
using CalorieCounterEngine.Utils;

namespace Console_App.ConfigModules
{
    public class CalorieCounterEngineConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GoalFactory>().As<IGoalFactory>().SingleInstance();
            builder.RegisterType<ProductFactory>().As<IProductFactory>().SingleInstance();
            builder.RegisterType<ActivityFactory>().As<IActivityFactory>().SingleInstance();
            builder.RegisterType<DailyNutriCalc>().As<IDailyNutriCalc>().SingleInstance();
            builder.RegisterType<RestingEnergyCalculator>().As<IRestingEnergyCalculator>().SingleInstance();
            builder.RegisterType<JsonSerializer>().As<IJsonSerializer>().SingleInstance();
            builder.RegisterType<SuggestedDailyNutrientsIntakeCalc>().As<ISuggestedDailyNutrientsIntakeCalc>().SingleInstance();
            builder.RegisterType<DataRepository>().As<IDataRepository>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
        }
    }
}
