using System;
using MortalEngines.Core;
using MortalEngines.Entities;
using MortalEngines.Entities.Machines;

namespace MortalEngines
{
    public class StartUp
    {
        private static Engine engine;

        public static void Main()
        {
            engine =new Engine();
            engine.Run();
        }
    }
}