using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
        {
            get
            {
                return this.models.AsReadOnly();
            }
        }

        public void Add(IPlanet model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models.FirstOrDefault(p => p.Name == name);

            return planet;
        }
    }
}
