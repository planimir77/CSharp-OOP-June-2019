namespace RawData
{
    public class Car
    {

        public Car(string[] parameters)
        {
            this.Tires = new Tire[4];

            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            int index = 0;
            for (int i = 5; i <= 12; i += 2)
            {
                var tirePressure = double.Parse(parameters[i]);
                var tireAge = int.Parse(parameters[i + 1]);
                Tires[index] = new Tire(tirePressure, tireAge);
                index++;
            }

            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public Tire[] Tires { get; private set; }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
