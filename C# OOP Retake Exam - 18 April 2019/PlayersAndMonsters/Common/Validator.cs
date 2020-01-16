using System;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ThrowIfNumberIsOrNegative(int value, string massage)
        {
            if (value < 0)
            {
                throw new ArgumentException(massage);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string value, string massage)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException(massage);
            }
        }

    }
}
