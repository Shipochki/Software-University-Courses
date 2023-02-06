using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuatity;
        private double fuelConsumption;
        private Engine engine;
        private List<Tire> tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
            this.Engine = new Engine(0, 0);
            this.Tires = new List<Tire>();
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, List<Tire> tires) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuatity; }
            set { fuelQuatity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - distance * (this.FuelConsumption / 100) >= 0)
            {
                this.fuelQuatity -= distance * (this.FuelConsumption / 100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder outpud = new StringBuilder();
            outpud.AppendLine($"Make: {this.Make}");
            outpud.AppendLine($"Model: {this.Model}");
            outpud.AppendLine($"Year: {this.Year}");
            outpud.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            outpud.AppendLine($"FuelQuantity: {this.FuelQuantity:f1}");

            return outpud.ToString().TrimEnd();
        }
    }
}
