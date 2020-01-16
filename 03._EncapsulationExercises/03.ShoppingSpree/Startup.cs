using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Startup
    {
        static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var inputPerson = Console.ReadLine()?
                .Split(new char[]{'=',';'});

            var inputProduct = Console.ReadLine()?
                .Split(new[] { '=', ';' },StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < inputPerson?.Length; i += 2)
            {
                try
                {
                    var personName = inputPerson[i];
                    var personMoney = decimal.Parse(inputPerson[i + 1]);

                    var person = new Person(personName, personMoney);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            for (int j = 0; j < inputProduct?.Length; j += 2)
            {
                try
                {
                    var productName = inputProduct[j];
                    var productCost = decimal.Parse(inputProduct[j + 1]);
                    var product = new Product(productName, productCost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            var command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokkens = command?
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = tokkens?[0];
                var productName = tokkens?[1];
                var product = products.FirstOrDefault(x => x.Name == productName);
                var currentPeople = people.FirstOrDefault(x => x.Name == name);

                try
                {
                    
                    if (currentPeople != null)
                    {
                        currentPeople.BuyProduct(product);
                        
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

            
        }
    }
}
