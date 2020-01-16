using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _04.Telephony
{
    public class Smartphone:ICallingOtherPhones, IBrowsingWww
    {

        public string Call(string number)
        {
            if (!number.All(predicate: Char.IsDigit))
            {
                throw new ArgumentException(Exceptions.Exceptions.InvalidPhoneNumberExceptions);
            }
            return $"Calling... {number}";
        }
        
        public string Browse(string url)
        {
            if (url.Any(predicate: Char.IsDigit))
            {
                throw new ArgumentException(Exceptions.Exceptions.InvalidUrlExceptions);
            }
            return $"Browsing: {url}!";
        }

    }
}

    
