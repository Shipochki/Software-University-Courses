using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsPerKm = double.Parse(input[2]);

                var car = new Car(model, fuelAmount, fuelConsPerKm);
                cars.Add(car);
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Drive")
                {
                    string carModel = input[1];
                    double amountOfKm = double.Parse(input[2]);

                    Car currentCar = cars.First(car => car.Model == carModel);
                    currentCar.Drive(amountOfKm);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
