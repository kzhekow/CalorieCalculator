namespace Console_App.Core.Engine
{
    public static class EngineConstants
    {
        // Commands
        internal const string CreateFoodProduct = "CreateFoodProduct";

        internal const string CreateDrink = "CreateDrink";
        internal const string AddConsumedProduct = "AddConsumedProduct";
        internal const string AddWater = "AddWater";
        internal const string RemoveProduct = "RemoveProduct";
        internal const string AddActivity = "AddActivity";
        internal const string ShowAllProducts = "ShowAllProducts";
        internal const string ShowRemainingNutrients = "ShowRemainingNutrients";
        internal const string ShowDailyReport = "ShowDailyReport";
        internal const string SetGoal = "SetGoal";

        internal const string HelpMenu = "Available commands: \r\n";

        // Activity levels
        internal const string Light = "Light";

        internal const string Moderate = "Moderate";
        internal const string Heavy = "Heavy";

        // Activity types
        internal const string Cardio = "Cardio";

        internal const string StrengthTraining = "StrengthTraining";

        // Gender types
        internal const string Male = "Male";

        internal const string Female = "Female";

        // Goal types
        internal const string LoseWeight = "LoseWeight";

        internal const string MaintainWeight = "MaintainWeight";
        internal const string GainWeight = "GainWeight";

        // Meal types
        internal const string Breakfast = "Breakfast";

        internal const string Lunch = "Lunch";
        internal const string Dinner = "Dinner";
        internal const string Snack = "Snack";

        // Error messages
        internal const string InvalidCommandErrorMessage = "Invalid command name: {0}";

        internal const string FoodProductExistsErrorMessage = "Food product {0} already exists";
        internal const string FoodProductNotFoundErrorMessage = "Food product {0} not found";
        internal const string MealExistsErrorMessage = "Meal {0} already exists";
        internal const string MealNotFoundErrorMessage = "Meal {0} not found";
        internal const string DrinkExistsErrorMessage = "Drink {0} already exists";
        internal const string DrinkNotFoundErrorMessage = "Drink {0} not found";
        internal const string WaterNotFoundErrorMessage = "Water {0} not found";
        internal const string InvalidActivityLevelErrorMessage = "Invalid activity level: {0}";
        internal const string InvalidActivityTypeErrorMessage = "Invalid activity type: {0}";
        internal const string InvalidGenderTypeErrorMessage = "Invalid gender type: {0}";
        internal const string InvalidGoalTypeErrorMessage = "Invalid goal type: {0}";
        internal const string InvalidMealTypeErrorMessage = "Invalid meal type: {0}";
        internal const string ShowProductsErrorMessage = "No products have been created";

        // Success messages
        internal const string FoodProductCreatedSuccessMessage = "Food product {0} created";

        internal const string MealCreatedSuccessMessage = "Meal {0} created";
        internal const string DrinkCreatedSuccessMessage = "Drink {0} created";
        internal const string ConsumedProductAddedSuccessMessage = "Product {0} successfully added to current day {1}";
        internal const string WaterAddedSuccessMessage = "Water successfully added to current day {0}";
        internal const string ProductRemovedSuccessMessage = "Product {0} successfully removed from current day {1}";
        internal const string ActivityAddedSuccessMessage = "Activity {0} successfully added to current day {1}";
        internal const string GoalCreatedSuccessMessage = "New goal {0} successfully created";
    }
}