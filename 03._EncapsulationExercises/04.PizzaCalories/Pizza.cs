using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        public List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public List<Topping> Toppings { get; private set; }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public string Name
        {   
            get { return this.name;}
            private set
            {
                if (value.Length < 1 || value.Length > 15 )
                {
                    throw new ArgumentException(Exceptions.ExceptionMessage.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
                this.Toppings.Add(topping);
        }

        private double TotalCalories()
        {
            double totalCalories = this.Dough.TotalCalories() + this.Toppings.Sum(x => x.ToppingCalories());

            return totalCalories;
        }

        public override string ToString()
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException(Exceptions.ExceptionMessage.InvalidNumberOfToppingsException);
            }
            var sb = new StringBuilder();
            sb.Append($"{this.Name} - {TotalCalories():F2} Calories.");
            return sb.ToString().TrimEnd();
        }
    }
}
