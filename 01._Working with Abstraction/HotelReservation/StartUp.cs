using System;
using System.Linq;

namespace HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"{PriceCalculator.GetTotalPrice(input):F2}");
        }
    }
}
