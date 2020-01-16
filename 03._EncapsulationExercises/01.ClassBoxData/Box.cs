using System;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length,double width,double height)
        {
            
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }

                this.length = value;

            }

        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }


                this.width = value;
            } 

        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }

                this.height = value;
            }

        }
        
        public void CalculateSurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width + 2 * this.Length * this.Height +
                                 2 * this.Width * this.Height;
            Console.WriteLine($"Surface Area - {surfaceArea:F2}");
        }

        public void CalculateLateralSurfaceArea()
        {
            double calculateLateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            Console.WriteLine($"Lateral Surface Area - {calculateLateralSurfaceArea:F2}");
        }

        public void CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;

            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
