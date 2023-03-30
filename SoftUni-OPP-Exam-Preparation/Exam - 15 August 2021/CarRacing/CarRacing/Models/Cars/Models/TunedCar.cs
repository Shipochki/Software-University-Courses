using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars.Models
{
    public class TunedCar : Car
    {
        private const double initalFuelAvailable = 65;
        private const double initalFuelConsumption = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, initalFuelAvailable, initalFuelConsumption)
        {
        }

        public override void Drive()
        {
            base.Drive();
            base.horsePower = (int)Math.Round(this.horsePower - base.horsePower * 0.03, 1);
        }
    }
}
