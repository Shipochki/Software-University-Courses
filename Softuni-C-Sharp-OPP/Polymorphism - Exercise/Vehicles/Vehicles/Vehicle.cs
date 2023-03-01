using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuel_Quantity;
        protected double fuel_Cons_Per_Km;
        protected double tank_Capacity;

        protected double FuelQuanitity
        {
            get { return this.fuel_Quantity; }
            set
            {
                if (value > tank_Capacity)
                {
                    fuel_Quantity = 0;
                }

                fuel_Quantity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            if (distance <= fuel_Quantity / fuel_Cons_Per_Km)
            {
                fuel_Quantity -= distance * fuel_Cons_Per_Km;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
                throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        public virtual void Refuel(double quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Fuel must be a positive number");
            else if (quantity > tank_Capacity - fuel_Quantity)
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");

            this.fuel_Quantity += quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {fuel_Quantity:f2}";
        }
    }
}
