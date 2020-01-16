namespace RawData
{
    using System.Collections.Generic;

    public class Cars
    {
        public Cars()
        {
            this.CarsList = new List<Car>();
        }

        public List<Car> CarsList { get; set; }

        public void Add(Car car)
        {
            this.CarsList.Add(car);
        }
    }
}
