using Autofac;
using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Factories.Contracts;
using CalorieCounter;
using CalorieCounter.Models.Utils;
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
            builder.RegisterType<RestingEnergy>().As<IRestingEnergy>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
        }
    }
}
