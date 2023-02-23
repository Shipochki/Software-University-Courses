using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double Coffee_Milliters = 50;
        private const decimal Coffee_Price = 3.50m;
        private double caffeine;
        public Coffee(string name, double caffeine) : base(name, Coffee_Price, Coffee_Milliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }
    }
}
