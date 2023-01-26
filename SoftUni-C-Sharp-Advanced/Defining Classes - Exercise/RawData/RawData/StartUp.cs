using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numOfCars = int.Parse(Console.ReadLine());

            for (int carIndex = 0; carIndex < numOfCars; carIndex++)
            {
                var data = Console.ReadLine().Split();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoType, cargoWeight);

                var tires = new List<Tires>();

                for (int i = 5; i < 12; i++)
                {
                    var tire = new Tires(int.Parse(data[i + 1]), float.Parse(data[i]));
                    i++;
                    tires.Add(tire);
                }

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string comand = Console.ReadLine();

            foreach (Car car in cars)
            {
                if (comand == "fragile" && car.Tires.Any(tire => tire.Tire1Pressure < 1) && car.Cargo.Type == comand)
                {
                    Console.Write($"{car.Model}");
                }
                else if(comand == "flammable" && car.Cargo.Type == comand && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
