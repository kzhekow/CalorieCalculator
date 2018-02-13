using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounterEngine.Contracts;
using Moq;

namespace CalorieCounter.UnitTests.Builders
{
    internal class EngineBuilder
    {
        private IProductFactory productFactory;
        private IActivityFactory activityFactory;
        private IGoalFactory goalFactory;
        private IDailyNutriCalc dailyNutriCalc;
        private IRestingEnergyCalculator restingEnergyCalculator;
        private IJsonSerializer jsonSerializer;
        private IDataRepository dataRepository;

        internal EngineBuilder()
        {
            this.productFactory = new Mock<IProductFactory>().Object;
            this.activityFactory = new Mock<IActivityFactory>().Object;
            this.goalFactory = new Mock<IGoalFactory>().Object;
            this.dailyNutriCalc = new Mock<IDailyNutriCalc>().Object;
            this.restingEnergyCalculator = new Mock<IRestingEnergyCalculator>().Object;
            this.jsonSerializer = new Mock<IJsonSerializer>().Object;
            this.dataRepository = new Mock<IDataRepository>().Object;
        }

        internal EngineBuilder WithProductFactory(IProductFactory productFactory)
        {
            this.productFactory = productFactory;
            return this;
        }

        internal EngineBuilder WithActivityFactory(IActivityFactory activityFactory)
        {
            this.activityFactory = activityFactory;
            return this;
        }

        internal EngineBuilder WithGoalFactory(IGoalFactory goalFactory)
        {
            this.goalFactory = goalFactory;
            return this;
        }

        internal EngineBuilder WithDailyNutriCalc(IDailyNutriCalc dailyNutriCalc)
        {
            this.dailyNutriCalc = dailyNutriCalc;
            return this;
        }

        internal EngineBuilder WithRestingEnergyCalculator(IRestingEnergyCalculator restingEnergyCalculator)
        {
            this.restingEnergyCalculator = restingEnergyCalculator;
            return this;
        }
        
        internal EngineBuilder WithJsonSerializer(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
            return this;
        }

        internal EngineBuilder WithDataRepository(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
            return this;
        }

        internal IEngine Build()
        {
            return new Engine(this.productFactory, this.activityFactory, this.goalFactory, this.dailyNutriCalc, this.restingEnergyCalculator, this.jsonSerializer, this.dataRepository);
        }
    }
}
