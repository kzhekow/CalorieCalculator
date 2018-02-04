using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.CustomException;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;

namespace Console_App.Core.Commands.Creating
{
    internal class SetGoalCommand : BaseCommand
    {

        public SetGoalCommand(IEngine calorieCounterEngine) 
            : base(calorieCounterEngine)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            double startingWeight;
            double goalWeight;
            double height;
            int age;
            GenderType gender;
            GoalType goalType;
            ActivityLevel acitvityLevel;

            //sb.AppendLine($"- {EngineConstants.CreateGoal} [startingWeight] [goalWeight] [height] [age] [gender] [goalType] [activityLevel]");
            
            try

            {
                startingWeight = double.Parse(parameters[0]);
                goalWeight = double.Parse(parameters[1]);
                height = double.Parse(parameters[2]);
                age = int.Parse(parameters[3]);
                gender = (GenderType)Enum.Parse(typeof(GenderType), parameters[4].ToLower());
                goalType = (GoalType)Enum.Parse(typeof(GoalType), parameters[5].ToLower());
                acitvityLevel = (ActivityLevel)Enum.Parse(typeof(ActivityLevel), parameters[6].ToLower());
            }
            catch
            {
                throw new CommandParseЕxception(
                    "[startingWeight] [goalWeight] [height] [age] [gender: male/female] [goalType: LoseWeight/MaintainWeight/GainWeight] [activityLevel: Light/Moderate/Heavy]");
            }

            object[] args = { startingWeight, goalWeight, height, age, gender, goalType, acitvityLevel };
            if (this.CalorieCounterEngine.SetGoalCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.SetGoalCommand.Execute(args);
            }

            return $"Goal was successfully set!";
        }
    }
}