//using CalorieCounter.Contracts;
//using CalorieCounter.Models.Contracts;
//using CalorieCounterEngine.Contracts;
//using System;

//namespace CalorieCounter.UnitTests.Mocks
//{
//    internal class SuggestedDailyNutrientsIntakeCalcFake : ISuggestedDailyNutrientsIntakeCalc
//    {
//        private readonly IGoal currentGoal;
//        private readonly IRestingEnergyCalculator restingEnergy;

//        public SuggestedDailyNutrientsIntakeCalcFake(IGoal currentGoal, IRestingEnergyCalculator restingEnergy)
//        {
//            this.currentGoal = currentGoal;
//            this.restingEnergy = restingEnergy;
//        }

//        public double DailyCalorieIntake => throw new NotImplementedException();

//        public double SuggestedDailyCalorieIntakeExposed { get; set; }

//        public double RestingEnergy => throw new NotImplementedException();

//        public double CalculateSuggestedDailyCalorieIntake()
//        {
//            throw new NotImplementedException();
//        }

//        public double CalculateSuggestedDailyCarbsIntake()
//        {
//            double suggestCarbsIntake = 0;

//            switch (this.currentGoal.GoalType)
//            {
//                case GoalType.loseweight:
//                    suggestCarbsIntake = 0.25 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                case GoalType.maintainweight:
//                    suggestCarbsIntake = 0.4 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                case GoalType.gainweight:
//                    suggestCarbsIntake = 0.5 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                default:
//                    break;
//            }

//            return suggestCarbsIntake;
//        }

//        public double CalculateSuggestedDailyProteinIntake()
//        {
//            double suggestProteinIntake = 0;

//            switch (this.currentGoal.GoalType)
//            {
//                case GoalType.loseweight:
//                    suggestProteinIntake = 0.4 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                case GoalType.maintainweight:
//                    suggestProteinIntake = 0.3 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                case GoalType.gainweight:
//                    suggestProteinIntake = 0.3 * SuggestedDailyCalorieIntakeExposed / 4;
//                    break;
//                default:
//                    break;
//            }

//            return suggestProteinIntake;
//        }

//        public double CalculateSuggestedDailyFatIntake()
//        {
//            double suggestFatIntake = 0;

//            switch (this.currentGoal.GoalType)
//            {
//                case GoalType.loseweight:
//                    suggestFatIntake = Math.Round(0.35 * SuggestedDailyCalorieIntakeExposed / 9);
//                    break;
//                case GoalType.maintainweight:
//                    suggestFatIntake = Math.Round(0.3 * SuggestedDailyCalorieIntakeExposed / 9);
//                    break;
//                case GoalType.gainweight:
//                    suggestFatIntake = Math.Round(0.2 * SuggestedDailyCalorieIntakeExposed / 9);
//                    break;
//                default:
//                    break;
//            }

//            return suggestFatIntake;
//        }

//        public string CalculateSuggestedMacrosRatio()
//        {
//            throw new NotImplementedException();
//        }

//        public int CalculateSuggestedWaterIntake()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

