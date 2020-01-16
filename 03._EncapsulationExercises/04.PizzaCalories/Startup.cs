using System;

namespace PizzaCalories
{
    
    public class Startup
    {
        static void Main()
        {
            var inputOfPizza = Console.ReadLine()
                ?.Split();

            try
            {
                var pizza = new Pizza(inputOfPizza[1]);

                var inputOfDough = Console.ReadLine()?
                    .Split();

                pizza.Dough = new Dough(inputOfDough?[0], inputOfDough?[1], inputOfDough?[2]
                                     , int.Parse(inputOfDough?[3]));


                string command = Console.ReadLine();

                while (command != "END")
                {
                    var toppingParts = command?
                        .Split();
                    var toppingType = toppingParts?[1];
                    var toppingWeight = int.Parse(toppingParts?[2]);

                    var topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }
                
                Console.WriteLine(pizza.ToString());

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
