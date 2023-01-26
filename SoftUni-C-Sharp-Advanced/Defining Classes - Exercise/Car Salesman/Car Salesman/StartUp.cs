using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var engines = new List<Engine>();

            int numOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEngines; i++)
            {
                var data = Console.ReadLine().Split().ToList();

                string model = data[0];
                int power = int.Parse(data[1]);
                Engine engine;
                if (data.Count == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (data.Count == 3)
                {
                    int displacment;
                    bool isNum = int.TryParse(data[2], out displacment);
                    if (isNum)
                        engine = new Engine(model, power, displacment);
                    else
                        engine = new Engine(model, power, data[2]);
                }
                else
                {
                    int displacment = int.Parse(data[2]);
                    string color = data[3];
                    engine = new Engine(model, power, displacment, color);
                }

                engines.Add(engine);
            }

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                var data = Console.ReadLine().Split().ToList();

                string model = data[0];
                string modelEngine = data[1];
                Engine currentEngine = engines.First(en => en.Model == modelEngine);

                Car car;
                if (data.Count == 2)
                    car = new Car(model, currentEngine);
                else if (data.Count == 3)
                {
                    int weight;
                    bool isNum = int.TryParse(data[2], out weight);
                    if (isNum)
                        car = new Car(model, currentEngine, weight);
                    else
                        car = new Car(model, currentEngine, data[2]);
                }
                else
                {
                    int weight = int.Parse(data[2]);
                    string color = data[3];
                    car = new Car(model, currentEngine, weight, color);
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {

                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                if (car.Engine.Displacement == 0)
                    Console.WriteLine($"   Displacement: n/a");
                else
                    Console.WriteLine($"   Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                if (car.Weight == 0)
                    Console.WriteLine($" Weight: n/a");
                else
                    Console.WriteLine($" Weight: {car.Weight}");
                Console.WriteLine($" Color: {car.Color}");
            }
        }
    }
}
