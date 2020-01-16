using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Vehicles
{
    public class Bus:Vehicle
    {
        private const double IncreaseConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            var neededFuel = distance * (FuelConsumption + IncreaseConsumption);

            if (FuelQuantity - neededFuel >= 0)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            var neededFuel = distance * FuelConsumption;

            if (FuelQuantity - neededFuel >= 0)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters;
            }
        }
    }
}
