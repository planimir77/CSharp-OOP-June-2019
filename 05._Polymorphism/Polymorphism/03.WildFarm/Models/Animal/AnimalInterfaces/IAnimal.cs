namespace _03.WildFarm.Models.Animal.AnimalInterfaces
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get;}

        int FoodEaten { get;}

        string AskFood();

        void Feed(Food.Entities.Food food);
    }
}
