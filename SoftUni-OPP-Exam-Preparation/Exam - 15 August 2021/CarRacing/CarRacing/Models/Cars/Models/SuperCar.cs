using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars.Models
{
    public class SuperCar : Car
    {
        private const double initalFuelAvailable = 80;
        private const double initalFuelConsumption = 10;
        public SuperCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, initalFuelAvailable, initalFuelConsumption)
        {
        }
    }
}
