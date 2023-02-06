using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarData
{
    public class Car
    {
        private double tavelledDistance = 0;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDistance
        {
            get { return tavelledDistance; }
            set { tavelledDistance = value; }
        }

        public void Drive(double distance)
        {
            if(FuelAmount - distance * FuelConsumptionPerKm >= 0)
            {
                FuelAmount -= distance * FuelConsumptionPerKm;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
