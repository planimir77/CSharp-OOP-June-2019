using System.Text;
using ShoppingSpree.Exceptions;

namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money;}
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }

                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            var moneyLeft = this.Money - product.Cost;
            if (moneyLeft<0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.PersonCanNotAffordProduct,this.Name, product));
            }
            else
            {
                this.Money = moneyLeft;
                this.bag.Add(product);
                Console.WriteLine($"{this.Name} bought {product}");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.bag.Count > 0 ? $"{this.Name} - {String.Join(", ", bag)}" 
                                         : $"{this.Name} - Nothing bought");

            return sb.ToString().TrimEnd();
        }
    }
}
