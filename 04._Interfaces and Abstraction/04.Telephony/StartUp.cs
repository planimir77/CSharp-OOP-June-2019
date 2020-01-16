using System;

namespace _04.Telephony
{
    public class StartUp
    {
        public static Smartphone phone;
        static void Main()
        {
            var numbers = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var urls = Console.ReadLine()
                ?.Split(" ");

            phone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(phone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }
        }
    }
}
