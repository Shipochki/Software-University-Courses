namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<List<Tire>> tires = AddDataForTires();
            List<Engine> engines = AddDataForEngines();
            List<Car> cars = AddDataForCars(tires, engines);

            List<Car> specialCars = GetSpecialCars(cars);

            PrintSpecialCars(specialCars);
        }

        private static void PrintSpecialCars(List<Car> specialCars)
        {
            foreach (var car in specialCars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static List<Car> GetSpecialCars(List<Car> cars)
        {
            List<Car> specialCars = new List<Car>();

            foreach (var car in cars)
            {
                if(car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) > 9 && car.Tires.Sum(t => t.Pressure) < 10)
                {
                    car.Drive(20);
                    specialCars.Add(car);
                }
            }

            return specialCars;
        }

        private static List<Car> AddDataForCars(List<List<Tire>> tiresArray, List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            while (true)
            {
                string inputData = Console.ReadLine();

                if(inputData == "Show special")
                {
                    break;
                }

                string[] splitedData = inputData
                    .Split()
                    .ToArray();

                string make = splitedData[0];
                string model = splitedData[1];
                int year = int.Parse(splitedData[2]);
                double fuelQuantity = double.Parse(splitedData[3]);
                double fuelConsumption = double.Parse(splitedData[4]);
                int engineIndex = int.Parse(splitedData[5]);
                int tiresIndex = int.Parse(splitedData[6]);

                Engine engine = engines[engineIndex];
                List<Tire> tires = tiresArray[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                cars.Add(car);
            }

            return cars;
        }

        private static List<Engine> AddDataForEngines()
        {
            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "Engines done")
                {
                    break;
                }

                double[] splitedData = inputData
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                int horsePower = (int)splitedData[0];
                double cubicCapacity = splitedData[1];

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            return engines;
        }

        private static List<List<Tire>> AddDataForTires()
        {
            List<List<Tire>> tires = new List<List<Tire>>();

            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "No more tires")
                {
                    break;
                }

                double[] splitedData = inputData.Split()
                    .Select(double.Parse)
                    .ToArray();

                Tire frontLeftTire = new Tire((int)splitedData[0], splitedData[1]);
                Tire frontRightTire = new Tire((int)splitedData[2], splitedData[3]);
                Tire backLeftTire = new Tire((int)splitedData[4], splitedData[5]);
                Tire backRightTire = new Tire((int)splitedData[6], splitedData[7]);

                List<Tire> currentTires = new List<Tire>();
                currentTires.Add(frontLeftTire);
                currentTires.Add(frontRightTire);
                currentTires.Add(backLeftTire);
                currentTires.Add(backRightTire);

                tires.Add(currentTires);
            }

            return tires;
        }
    }
}
