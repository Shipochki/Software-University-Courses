using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double Fuel_Consum_With_People = 1.4; 
        public Bus(double fuelQuantity, double fuelConsumPerKm, double tankCapacity)
        {
            base.FuelQuanitity = fuelQuantity;
            base.fuel_Cons_Per_Km = fuelConsumPerKm;
            base.tank_Capacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumeWithPeople = base.fuel_Cons_Per_Km + Fuel_Consum_With_People;
            if (distance <= fuel_Quantity / consumeWithPeople)
            {
                fuel_Quantity -= distance * consumeWithPeople;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
                throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        public void DriveEmpty(double distance)
        {
            if (distance <= base.fuel_Quantity / base.fuel_Cons_Per_Km)
            {
                base.fuel_Quantity -= distance * base.fuel_Cons_Per_Km;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
                throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
        }
    }
}
