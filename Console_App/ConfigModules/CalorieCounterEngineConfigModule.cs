﻿//using Autofac;
//using CalorieCounter;
//using CalorieCounter.Contracts;
//using CalorieCounter.Factories;
//using CalorieCounter.Factories.Contracts;

//namespace Console_App.ConfigModules
//{
//    public class CalorieCounterEngineConfigModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterType<GoalFactory>().As<IGoalFactory>().SingleInstance();
//            builder.RegisterType<ProductFactory>().As<IProductFactory>().SingleInstance();
//            builder.RegisterType<ActivityFactory>().As<IActivityFactory>().SingleInstance();
//            builder.RegisterType<CalorieCounterEngine>().As<ICalorieCounterEngine>().SingleInstance();
//        }
//    }
//}
