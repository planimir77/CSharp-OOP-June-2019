using System;
using System.Text;

namespace _03.WildFarm.Models.Animal.Mammal
{
    public class Mouse:Mammal
    {
        private const double Increase = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskFood()
        {
            return "Squeak";
        }

        public override void Feed(Food.Entities.Food food)
        {
            var type = food.GetType().Name;

            switch (type)
            {
                case "Vegetable":
                    
                case "Fruit":
                    this.FoodEaten += food.Quantity;
                    this.Weight += food.Quantity * Increase;
                    break;
                default:
                    Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                    break;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]");
            return sb.ToString();
        }
    }
}
