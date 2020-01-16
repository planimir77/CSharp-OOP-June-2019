using _03.WildFarm.Models.Animal.AnimalInterfaces;

namespace _03.WildFarm.Models.Animal
{
    public abstract class Animal:IAnimal
    {
        private string _name;
        private double _weight;
        private int _foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public double Weight
        {
            get { return _weight; }
            protected set { _weight = value; }
        }

        public int FoodEaten
        {
            get { return _foodEaten; }
            protected set { _foodEaten = value; }
        }

        public abstract string AskFood();

        public abstract void Feed(Food.Entities.Food food);
    }
}
