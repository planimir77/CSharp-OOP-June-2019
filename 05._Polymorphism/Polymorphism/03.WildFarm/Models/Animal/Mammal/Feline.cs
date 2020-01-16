using System.Text;

namespace _03.WildFarm.Models.Animal.Mammal
{
    public abstract class Feline:Mammal
    {
        protected Feline(string name, double weight,string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
