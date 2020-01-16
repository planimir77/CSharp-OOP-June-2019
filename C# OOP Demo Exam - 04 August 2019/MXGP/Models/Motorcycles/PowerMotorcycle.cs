using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MotorcycleMinimumHorsePower = 70;
        private const int MotorcycleMaximumHorsePower = 100;
        private const double MotorcycleCubicCentimeters = 450;

        private int _horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, MotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get
            {
                return _horsePower;
            }
            protected set
            {
                if (value < MotorcycleMinimumHorsePower || value > MotorcycleMaximumHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                _horsePower = value;
            }
        }  
    }
}
