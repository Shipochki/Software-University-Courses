using CarRacing.Models.Cars.Contracts;
using System;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars.Models
{
    public class Car : ICar
    {
        public Car(string make, string model, string VIN, int horsePower,
            double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        private string make;

        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidCarMake);
                }
                make = value;
            }
        }

        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidCarModel);
                }
                model = value;
            }
        }

        private string vin;

        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(InvalidCarVIN);
                }
                vin = value;
            }
        }

        protected int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarHorsePower);
                }
                horsePower = value;
            }
        }

        private double fuelAvailable;

        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set { fuelAvailable = value; }
        }

        private double fuelConsumptionPerRace;

        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidCarFuelConsumption);
                }
                fuelConsumptionPerRace = value;
            }
        }


        public virtual void Drive()
        {
            if (this.fuelAvailable - this.fuelConsumptionPerRace > 0)
            {
                this.fuelAvailable -= this.fuelConsumptionPerRace;
            }
            else
            {
                this.fuelAvailable = 0;
            }
        }
    }
}
