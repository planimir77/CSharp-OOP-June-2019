using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private int weight;
        private Dictionary<string, double> dict;
        private double toppingCalories;

        public Topping(string toppingType, int weight)
        {
            this.Dict = dict;
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        
        public string ToppingType
        {
            get { return this.toppingType; }
            private set
            {
                if (!this.dict.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(String.Format(Exceptions.ExceptionMessage.InvalidToppingException,value));
                }

                this.toppingType = value;
            }
        }

        public int Weight
        {
            get {return this.weight;}
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(String.Format(Exceptions.ExceptionMessage.InvalidToppingWeightException, this.ToppingType));
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
                dict.Add("sauce" , 0.9);
                dict.Add("cheese" , 1.1);
                dict.Add("veggies" , 0.8);
                dict.Add("meat" , 1.2);
            }
        }

        public double ToppingCalories()
        {
            var coefficient = this.Dict[toppingType.ToLower()];

            var totalCalories = 2.0 * this.weight * coefficient;

            return totalCalories;
        }
    }
}
