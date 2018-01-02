using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.CustomException;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;

namespace Console_App.Core.Commands.Creating
{
    internal class CreateGoalCommand : ICommand
    {
        private readonly ICalorieCounterEngine calorieCounterEngine;
        private readonly ICommandParserEngine engine;

        public CreateGoalCommand(ICommandParserEngine engine, ICalorieCounterEngine calorieCounterEngine)
        {
            this.engine = engine;
            this.calorieCounterEngine = calorieCounterEngine;
        }

        public string Execute(IList<string> parameters)
        {
            double startingWeight;
            double goalWeight;
            double height;
            int age;
            GenderType gender;
            GoalType type;
            ActivityLevel level;

            try
            {
                startingWeight = double.Parse(parameters[0]);
                goalWeight = double.Parse(parameters[1]);
                height = double.Parse(parameters[2]);
                age = int.Parse(parameters[3]);
                gender = (GenderType)Enum.Parse(typeof(GenderType), parameters[4]);
                type = (GoalType)Enum.Parse(typeof(GoalType), parameters[5]);
                level = (ActivityLevel)Enum.Parse(typeof(ActivityLevel), parameters[6]);
            }
            catch (Exception)
            {
                throw new CommandParseЕxception(
                    "The correct format for AddGoal is {startingWeight}{goalWeight}{height}{height}{age}{gender}{typeOfDailyActivity}{levelOfActivity}");
            }

            //var goal = this.factory.CreateGoal(startingWeight, goalWeight, height, age, gender, type, level);

            return $"Goal {type.ToString()} was created!";
        }
    }
}