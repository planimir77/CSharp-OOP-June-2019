namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist:Astronaut
    {
        private const int OxygenInitialUnits = 90;

        public Meteorologist(string name) 
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
