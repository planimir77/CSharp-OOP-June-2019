using System;

namespace _01.ClassBoxData.Core
{
    public class Engine
    {
        public Engine()
        {
            
        }

        public void Run()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                box.CalculateSurfaceArea();
                box.CalculateLateralSurfaceArea();
                box.CalculateVolume();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
