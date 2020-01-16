using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> _readers;

        public RiderRepository()
        {
            this._readers = new List<IRider>();
        }

        public IRider GetByName(string name) => _readers.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRider> GetAll() 
            => _readers.ToList();

        public void Add(IRider model) => _readers.Add(model);

        public bool Remove(IRider model)
        {
            return _readers.Remove(model);
        }
    }
}
