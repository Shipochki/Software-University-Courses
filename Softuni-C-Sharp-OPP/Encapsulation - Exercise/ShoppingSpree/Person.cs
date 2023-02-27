using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || value == " " || value == string.Empty)
                    throw new ArgumentException("Name cannot be empty");

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return this.bag; }
        }

        public void BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.money -= product.Cost;
                bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
                Console.WriteLine($"{Name} can't afford {product.Name}");
        }
    }
}
