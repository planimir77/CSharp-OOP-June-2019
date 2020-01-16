using System;

namespace _03.Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            var driver = Console.ReadLine();
            ICar car = new Ferrari(driver);
            Console.WriteLine(car);
        }
    }
}
