using System;
using System.Globalization;
using Logger.DateFormat;
using Logger.Exceptions;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Layouts;

namespace Logger.Factories
{
    public class ErrorFactory
    {

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, DateTimeFormat.DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
