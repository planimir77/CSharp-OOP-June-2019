using System;
using ViceCity.IO.Contracts;

namespace ViceCity.IO
{
    class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
