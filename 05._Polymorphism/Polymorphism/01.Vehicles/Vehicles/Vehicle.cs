using System.Text;

namespace _01.Vehicles.Vehicles
{
    public abstract class Vehicle:IVehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumption;
        private double _tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption ;
        }


        public double FuelQuantity
        {
            get { return _fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                {
                    _fuelQuantity = 0;
                }
                else
                {
                    _fuelQuantity = value;
                }
                
            }
        }

        public double FuelConsumption
        {
            get { return _fuelConsumption; }
            set { _fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return _tankCapacity;}
            set { _tankCapacity = value; }
        }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{GetType().Name}: {FuelQuantity:F2}");
            return sb.ToString();
        }
    }
}
