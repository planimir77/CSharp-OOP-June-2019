﻿using System;
using System.Collections.Generic;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet:IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Items = new List<string>();
            this.Name = name;
        }

        public ICollection<string> Items { get; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
    }
}
