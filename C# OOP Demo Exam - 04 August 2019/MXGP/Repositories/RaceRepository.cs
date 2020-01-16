using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> _motorcycles;

        public RaceRepository()
        {
            this._motorcycles = new List<IRace>();
        }

        public IRace GetByName(string name) 
            => _motorcycles.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll() 
            => _motorcycles.ToList();

        public void Add(IRace model) => _motorcycles.Add(model);

        public bool Remove(IRace model) => _motorcycles.Remove(model);
    }
}
