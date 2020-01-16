namespace RawData
{
    using System;
    using System.Linq;

    class RawData
    {
        static void Main(string[] args)
        {
            
            Cars cars = new Cars();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(parameters);
                
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine,cars.CarsList
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x=>x.Model)));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.CarsList
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)));
            }
        }
    }
}
