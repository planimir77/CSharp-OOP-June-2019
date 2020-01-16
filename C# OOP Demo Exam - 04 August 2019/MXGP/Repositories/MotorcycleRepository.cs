using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> _motorcycles;

        public MotorcycleRepository()
        {
            this._motorcycles = new List<IMotorcycle>();
        }

        public IMotorcycle GetByName(string name) => _motorcycles.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<IMotorcycle> GetAll() => _motorcycles.ToList();

        public void Add(IMotorcycle model) => _motorcycles.Add(model);

        public bool Remove(IMotorcycle model)
        {
            return _motorcycles.Remove(model);
        }
    }
}
