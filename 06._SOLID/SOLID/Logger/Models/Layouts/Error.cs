using System;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;

namespace Logger.Models.Layouts
{
    public class Error:IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
