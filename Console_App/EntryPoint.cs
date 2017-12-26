namespace Console_App
{
    using CalorieCounterEngine;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            var engine = Engine.Instance;

            //boxing the arguments
            string name = "Banan";
            decimal weight = 100;
            int protein = 1;
            int carbs = 20;
            int fat = 2;
            int calories = 100;
            int sugar = 15;
            int fiber = 3;
            object[] parameters = new object[]{name, protein, carbs, fat, calories, sugar, fiber} ;
            engine.CreateProductCommand.Execute(parameters);
        }
    }
}
