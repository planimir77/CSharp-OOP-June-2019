using System;

namespace _03.WildFarm.Models.Animal.Mammal
{
    public class Tiger:Feline
    {
        private const double Increase = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breet)
            : base(name, weight, livingRegion, breet)
        {
        }

        public override string AskFood()
        {
            return "ROAR!!!";
        }

        public override void Feed(Food.Entities.Food food)
        {
            var type = food.GetType().Name;

            switch (type)
            {
                case "Meat":
                    this.FoodEaten += food.Quantity;
                    this.Weight += food.Quantity * Increase;
                    break;
                default:
                    Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                    break;
            }
        }
    }
}
