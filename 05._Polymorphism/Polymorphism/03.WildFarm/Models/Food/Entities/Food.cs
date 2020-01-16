using _03.WildFarm.Models.Food.FoodInterfaces;

namespace _03.WildFarm.Models.Food.Entities
{
    public abstract class Food:IFood
    {
        private int _quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get { return _quantity; }
            private set { _quantity = value; }
        }
    }
}
