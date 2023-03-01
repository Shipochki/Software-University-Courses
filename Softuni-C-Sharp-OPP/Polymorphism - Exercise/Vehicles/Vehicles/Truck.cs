using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double Consum_Per_Km = 1.6;

        public Truck(double fuelQuantity, double fuelConsumPerKm, double tankCapacity)
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
            if (quantity <= 0)
                throw new ArgumentException("Fuel must be a positive number");
            else if (quantity > base.tank_Capacity - base.fuel_Quantity)
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");

            base.fuel_Quantity += quantity * 0.95;
        }
    }
}
