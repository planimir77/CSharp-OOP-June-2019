namespace _07.FoodShortage.Interface
{
    public interface IBuyer
    {
        int Food { get; set; }
        
        string Name { get; set; }

        int Age { get; set; }

        void BuyFood();
    }
}
