using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double Consum_Per_Km = 0.9;

        public Car(double fuelQuantity, double fuelConsumPerKm, double tankCapacity)
        {
            base.FuelQuanitity = fuelQuantity;
            base.fuel_Cons_Per_Km = fuelConsumPerKm + Consum_Per_Km;
            base.tank_Capacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            base.Drive(distance);
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
        }
    }
}
