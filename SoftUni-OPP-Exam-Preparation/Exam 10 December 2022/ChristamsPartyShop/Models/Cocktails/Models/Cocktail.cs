using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using static ChristmasPastryShop.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public class Cocktail : ICocktail
    {

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(NameNullOrWhitespace);
                }

                name = value;
            }
        }

        private string size;

        public string Size
        {
            get { return size; }
            private set
            {
                size = value;
            }
        }

        private double price;

        public double Price
        {
            get { return price; }
            private set
            {
                double currentPrice = value;

                if (this.size == "Middle")
                {
                    currentPrice = value * (2.00 /3.00);
                }
                else if (this.size == "Small")
                {
                    currentPrice = value * (1.00 / 3.00);
                }

                this.price = currentPrice;
            }
        }

        public override string ToString()
        {
            return $"{name} ({size}) - {price:f2} lv";
        }

    }
}
