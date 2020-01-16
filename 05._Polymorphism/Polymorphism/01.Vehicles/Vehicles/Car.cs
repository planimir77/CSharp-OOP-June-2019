using System;

namespace _01.Vehicles.Vehicles
{
    public class Car:Vehicle
    {
        private const double IncreaseConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            var neededFuel = distance * (FuelConsumption + IncreaseConsumption);

            if (FuelQuantity - neededFuel >= 0)
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
