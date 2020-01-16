using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController: IChampionshipController
    {
        private readonly IRepository<IRider> _riderRepository;
        private readonly IRepository<IMotorcycle> _motorRepository;
        private readonly IRepository<IRace> _raceRepository;

        public ChampionshipController()
        {
            _riderRepository = new RiderRepository();
            _motorRepository = new MotorcycleRepository();
            _raceRepository = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = _riderRepository.GetByName(riderName);
            
            if (rider!= null)
            {
                throw new ArgumentException($"Rider {rider.Name} is already created.");
            }
            rider = new Rider(riderName);
            _riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = _motorRepository.GetByName(model);
            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if(type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            _motorRepository.Add(motorcycle);

            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = _raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            race = new Race(name, laps);
            _raceRepository.Add(race);

            return $"Race {name} is created.";

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = _raceRepository.GetByName(raceName);
            var rider = _riderRepository.GetByName(riderName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            
            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";

        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = _riderRepository.GetByName(riderName);
            var motorcycle = _motorRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string StartRace(string raceName)
        {
            var race = _raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException("Race {name} could not be found.");
            }

            var participants = race.Riders.Count;

            if (participants < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(x=>x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            //If everything is successful, you should return the following message:
            sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            _raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
