using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> dict;
        private string flourType;
        private string bakingTechnique;
        private int weight;

        
        public Dough(string dough, string flourType, string bakingTechnique, int weight)
        {
            this.Dict = dict;
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (!this.Dict.ContainsKey(value))
                {
                    throw new ArgumentException(Exceptions.ExceptionMessage.InvalidDoughTypeException);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (!this.Dict.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(Exceptions.ExceptionMessage.InvalidDoughTypeException);
                }
                this.bakingTechnique = value;
            }
        }

        public int Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(Exceptions.ExceptionMessage.InvalidDoughWeightException);
                }
                this.weight = value;
            }

        }

        private Dictionary<string, double> Dict
        {
            get { return this.dict; }
            set
            {
                dict = value;
                this.dict = new Dictionary<string, double>();
                dict.Add("White", 1.5);
                dict.Add("Wholegrain", 1.0);
                dict.Add("crispy", 0.9);
                dict.Add("chewy", 1.1);
                dict.Add("homemade", 1.0);

            }
        }

        public double TotalCalories()
        {
            double flourTypeCoefficient = this.Dict[flourType];

            double bakingTechniqueCoefficient = this.Dict[bakingTechnique.ToLower()];

            double totalCalories = 2.0 * this.Weight * flourTypeCoefficient * bakingTechniqueCoefficient;

            return totalCalories;
        }
    }
}
