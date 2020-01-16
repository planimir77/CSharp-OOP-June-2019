using System;
using _01.Vehicles.Vehicles;

namespace _01.Vehicles.Core
{
    public class Engine
    {
        private static Car _car;
        private static Truck _truck;
        private static Bus _bus;

        public void Run()
        {
            var inputCar = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var inputTruck = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var inputBus = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            _car = CreateCar(inputCar);

            _truck = CreateTruck(inputTruck);

            _bus = CreateBus(inputBus);

            var numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                var command = Console.ReadLine()
                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentCommand = command?[0];
                var vehicleType = command?[1];

                switch (currentCommand)
                {
                    case "Drive":
                    {
                        var distance = double.Parse(command[2]);

                        Drive(distance, vehicleType);
                        break;
                    }

                    case "DriveEmpty":
                    {
                        var distance = double.Parse(command[2]);

                        DriveEmpty(distance);
                        break;
                    }

                    case "Refuel":
                    {
                        var liters = double.Parse(command[2]);
                        if (liters <= 0)
                        {
                            Console.WriteLine("Fuel must be a positive number");
                                break;
                        }
                        Refuel(liters, vehicleType);
                        break;
                    }
                }

            }

            Console.WriteLine(_car);
            Console.WriteLine(_truck);
            Console.WriteLine(_bus);
        }

        private void Refuel(double liters, string vehicleType)
        {
            if (vehicleType == "Car")
            {
                _car.Refuel(liters);
            }
            else if (vehicleType == "Truck")
            {
                _truck.Refuel(liters);
            }
            else if (vehicleType == "Bus")
            {
                _bus.Refuel(liters);
            }
        }

        private void DriveEmpty(double distance)
        {
            _bus.DriveEmpty(distance);
        }

        private void Drive(double distance, string vehicleType)
        {
            if (vehicleType == "Car")
            {
                _car.Drive(distance);
            }
            else if (vehicleType == "Truck")
            {
                _truck.Drive(distance);
            }
            else if (vehicleType == "Bus")
            {
                _bus.Drive(distance);
            }
        }

        private Bus CreateBus(string[] input)
        {
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsumtion = double.Parse(input[2]);
            var tankCapacity = double.Parse(input[3]);

            return new Bus(fuelQuantity, fuelConsumtion,tankCapacity);
        }

        private Truck CreateTruck(string[] input)
        {
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsumtion = double.Parse(input[2]);
            var tankCapacity = double.Parse(input[3]);

            return new Truck(fuelQuantity, fuelConsumtion, tankCapacity);
        }

        private Car CreateCar(string[] input)
        {
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsumtion = double.Parse(input[2]);
            var tankCapacity = double.Parse(input[3]);

            return new Car(fuelQuantity, fuelConsumtion, tankCapacity);
        }
    }
}
