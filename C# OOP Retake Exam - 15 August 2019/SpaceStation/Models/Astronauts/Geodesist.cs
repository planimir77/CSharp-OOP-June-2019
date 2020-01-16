namespace SpaceStation.Models.Astronauts
{
    public class Geodesist:Astronaut
    {
        private const int OxygenInitialUnits = 50;

        public Geodesist(string name) 
            : base(name, OxygenInitialUnits)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 10 <= 0)
            {
                this.Oxygen = 0;
            }

            this.Oxygen -= 10;
        }
    }
}
