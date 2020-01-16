using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        public readonly List<IRider> _riders;
        private string _name;
        private int _laps;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this._riders = new List<IRider>();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                _name = value;
            }
        }

        public int Laps
        {
            get
            {
                return _laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                _laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
        {
            get { return _riders.AsReadOnly(); }
        }

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider),"Rider cannot be null.");
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }

            if (_riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }

            this._riders.Add(rider);
        }
    }
}
