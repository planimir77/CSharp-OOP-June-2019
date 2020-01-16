namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; set; }

        double FuelConsumption { get; set; }

        double TankCapacity { get; set; }

        void Drive(double distance);

        void Refuel(double liters);

    }
}
