using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {

        public static decimal GetTotalPrice(string[] input)
        {
            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season season = Enum.Parse<Season>(input[2]);
            
            switch (season)
            {
                case Season.Autumn:
                    pricePerDay *= 1;
                    break;

                case Season.Spring:
                    pricePerDay *= 2;
                    break;

                case Season.Summer:
                    pricePerDay *= 4;
                    break;

                case Season.Winter:
                    pricePerDay *= 3;
                    break;

            }

            var sum = pricePerDay * numberOfDays;

            if (input.Length == 4)
            {
                Discount discountType = Enum.Parse<Discount>(input[3]);
                var discount = discountType;
                switch (discount)
                {
                    case Discount.None:
                        break;
                    case Discount.VIP:
                        sum *= (decimal)0.8;
                        break;
                    case Discount.SecondVisit:
                        sum *= (decimal) 0.9;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return sum;
        }
    }
}
