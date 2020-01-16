using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MotorcycleMinimumHorsePower = 50;
        private const int MotorcycleMaximumHorsePower = 69;
        private const double MotorcycleCubicCentimeters = 125;

        private int _horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
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
