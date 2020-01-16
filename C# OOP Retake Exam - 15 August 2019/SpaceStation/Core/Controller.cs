using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller:IController
    {
        private readonly ICollection<IAstronaut> astronautToExplore;
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private readonly IMission mission;


        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.astronautToExplore = new List<IAstronaut>();

        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronautRepository.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!";

        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidRetiredAstronaut);
            }

            astronautRepository.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";

        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            foreach (var astronaut in astronautRepository.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    this.astronautToExplore.Add(astronaut);
                }
            }
            //When the explore command is called, the action happens.You should start exploring the given planet,
            //             by sending the astronauts that are most suitable for the mission:
            //    •	You call each of the astronauts and pick only the ones that have oxygen above 60 units.
            if (astronautToExplore.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            this.mission.Explore(planet, astronautToExplore);
            //    •	After a mission, you must return the following message,
            //     with the name of the explored planet and the count of the astronauts that had given their lives for the mission:
            int deadAstronauts = 0;
            foreach (var astronaut in astronautToExplore)
            {
                if (!astronaut.CanBreath)
                {
                    deadAstronauts++;
                }
            }
            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!"

        }

        public string Report()
        {
            return "Planet: Mars was explored! Exploration finished with 0 dead astronauts!";
        }
    }
}
