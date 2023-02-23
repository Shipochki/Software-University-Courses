using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        private double milliters;
        public Beverage(string name, decimal price, double milliters) : base(name, price)
        {
            Milliters = milliters;
        }

        public double Milliters
        {
            get { return milliters; }
            set { milliters = value; }
        }
    }
}
