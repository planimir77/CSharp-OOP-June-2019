using System;

namespace _03.WildFarm.Models.Animal.Bird
{
    public class Owl:Bird
    {
        private const double Increase = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskFood()
        {
            return "Hoot Hoot";
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
