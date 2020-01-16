namespace SpaceStation.Models.Astronauts
{
    public class Biologist:Astronaut
    {
        private const int OxygenInitialUnits = 70;

        public Biologist(string name) 
            : base(name, OxygenInitialUnits)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 <= 0)
            {
                this.Oxygen = 0;
            }

            this.Oxygen -= 5;
        }
    }
}
