using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsPerKm;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsPerKm = fuelConsPerKm;
            TravelledDistance = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsPerKm
        {
            get { return fuelConsPerKm; }
            set { fuelConsPerKm = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(double amountOfKm)
        {
            double neededLiters = amountOfKm * fuelConsPerKm; 

            if (FuelAmount >= neededLiters)
            {
                FuelAmount -= neededLiters;
                travelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
