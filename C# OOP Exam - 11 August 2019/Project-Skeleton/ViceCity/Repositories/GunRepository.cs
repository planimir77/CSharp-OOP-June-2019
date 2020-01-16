using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IGun model)
        {
            if (this.Models.All(x => x.Name != model.Name))
            {
                this.models.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
