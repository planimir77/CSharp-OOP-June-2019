using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission:IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (true)
            {
                
                IAstronaut astronaut = astronauts.FirstOrDefault(a => a.CanBreath);
                if (astronaut == null)
                {
                    break;
                }
                var item = planet.Items.FirstOrDefault();

                if (item== null)
                {
                    break;
                }
                astronaut.Bag.Items.Add(item);
                astronaut.Breath();
                planet.Items.Remove(planet.Items.FirstOrDefault());
            }
        }
    }
}
