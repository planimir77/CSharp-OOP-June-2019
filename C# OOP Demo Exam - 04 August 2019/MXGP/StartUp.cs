﻿using System;
using MXGP.Core;
using MXGP.Models.Riders;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO Add IEngine
            Motorcycle varche = new PowerMotorcycle("12214235", 75);

            Console.WriteLine(varche.HorsePower);
            Console.WriteLine();
        }
    }
}
