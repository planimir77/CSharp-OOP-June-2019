using System.Text;
using ShoppingSpree.Exceptions;

namespace ShoppingSpree
{
    using System;

    public class Product
    {
        public string name;
        public decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Name}");
            return sb.ToString().TrimEnd();

        }
    }
}
