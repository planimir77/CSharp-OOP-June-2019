using System;

namespace _01.Vehicles.Vehicles
{
    public class Truck:Vehicle
    {
        private const double IncreaseConsumption = 1.6;
        private const double DecreaseFuel = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { 
        }

        public override void Drive(double distance)
        {
            var neededFuel = distance * (FuelConsumption + IncreaseConsumption);

            if (FuelQuantity - neededFuel >= 0)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (FuelQuantity + (liters* DecreaseFuel ) > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters * DecreaseFuel;

            }
        }
    }
}
