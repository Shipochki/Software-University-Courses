﻿using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
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

        public decimal Cost
        {
            get { return this.cost; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                this.cost = value;
            }
        }
    }
}