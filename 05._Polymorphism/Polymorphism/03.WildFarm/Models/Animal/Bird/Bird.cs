using System.Text;

namespace _03.WildFarm.Models.Animal.Bird
{
    public abstract class Bird:Animal
    {
        private double _wingSize;
        
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get { return _wingSize; }
            set { _wingSize = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{ this.GetType().Name} [{this.Name}, {WingSize }, {this.Weight}, {this.FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
