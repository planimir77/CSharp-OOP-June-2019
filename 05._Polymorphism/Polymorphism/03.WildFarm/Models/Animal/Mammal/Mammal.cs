﻿namespace _03.WildFarm.Models.Animal.Mammal
{
    public abstract class Mammal:Animal
    {
        

        protected Mammal(string name, double weight ,string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}
